

using weight;

namespace nSbllWeight
{
    public class bllWeight
    {
        public static float f_weight = 0.04f;
        public static uint l_weight = 0;
        public static ushort short_w = 0;
        public static ushort short_point = 0;

        public const byte modbus_addr = 0x01;
        public static byte[] CRC16(byte[] data, int len)
        {
            //int len = data.Length;
            if (len > 0)
            {
                ushort crc = 0xFFFF;

                for (int i = 0; i < len; i++)
                {
                    crc = (ushort)(crc ^ (data[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ 0xA001) : (ushort)(crc >> 1);
                    }
                }
                byte hi = (byte)((crc & 0xFF00) >> 8);  //高位置
                byte lo = (byte)(crc & 0x00FF);         //低位置

                return new byte[] { hi, lo };
            }
            return new byte[] { 0, 0 };
        }
        //只支持03，06命令
        public struct modbus_rtu
        {
            public byte addr;
            public byte cmd;
            public ushort data1;
            public ushort data2;
            public ushort crc;

            public int step;
            public int count;
        }

        private static modbus_rtu modbus_data = new modbus_rtu();
        
        public static bool parse_modbus_rtu(ref modbus_rtu mod,byte data)
        {
            bool ret = false;

            switch(mod.step)
            {
                case 0:
                    if(data== modbus_addr)
                    {
                        mod.step++;
                        mod.addr = data;
                    }
                    break;
                case 1:
                    if(data==0x03 || data==0x06)
                    {
                        mod.step++;
                        mod.cmd = data;
                        mod.count = 0;
                    }
                    break;
                case 2:
                    mod.count++;
                    if(mod.count>=2)
                    {
                        mod.step++;
                        mod.data1 = (ushort)(0x100 * mod.data1 + data);
                        mod.count = 0;
                    }
                    else
                    {
                        mod.data1 = data;
                    }
                    break;
                case 3:
                    mod.count++;
                    if (mod.count >= 2)
                    {
                        mod.step++;
                        mod.data2 = (ushort)(0x100 * mod.data2 + data);
                        mod.count = 0;
                    }
                    else
                    {
                        mod.data2 = data;
                    }
                    break;
                case 4:
                    mod.count++;
                    if (mod.count >= 2)
                    {
                        mod.step++;
                        mod.crc = (ushort)(0x100 * mod.crc + data);
                        byte[] buf = new byte[6];
                        buf[0] = mod.addr;
                        buf[1] = mod.cmd;
                        buf[2] = (byte)(mod.data1>>8);
                        buf[3] = (byte)(mod.data1&0x00ff);
                        buf[4] = (byte)(mod.data2 >> 8);
                        buf[5] = (byte)(mod.data2 & 0x00ff);

                        byte[] crc_byte = new byte[2];
                        crc_byte = CRC16(buf,6);
                        ushort crc_short = (ushort)(crc_byte[0] + 0x100*crc_byte[1]);
                        if(mod.crc == crc_short)
                        {
                            ret = true;
                        }
                        mod.step = 0;
                    }
                    else
                    {
                        mod.crc = data;
                    }
                    break;
                default:
                    mod.step = 0;
                    break;
            }
            return ret;
        }
        private static void deal_com_cmd(modbus_rtu data)
        {
            byte[] buf = new byte[128];
            byte[] crc = new byte[2];
            switch(data.cmd)
            {
                case 0x03:
                    if(data.data1==0x0004 && data.data2 == 0x0002)
                    {
                        buf[0] = modbus_addr;
                        buf[1] = data.cmd;
                        buf[2] = 4;
                        buf[3] = (byte)(l_weight>>24);
                        buf[4] = (byte)(l_weight >> 16);
                        buf[5] = (byte)(l_weight >> 8);
                        buf[6] = (byte)(l_weight >> 0);
                        crc = CRC16(buf,7);
                        buf[7] = crc[1];
                        buf[8] = crc[0];

                        Form1.com.Write(buf,0,9);
                    }
                    if (data.data1 == 0x0006 && data.data2 == 0x0002)
                    {
                        buf[0] = modbus_addr;
                        buf[1] = data.cmd;
                        buf[2] = 4;
                        buf[3] = (byte)(short_w >> 8);
                        buf[4] = (byte)(short_w >> 0);
                        buf[5] = (byte)(short_point >> 8);
                        buf[6] = (byte)(short_point >> 0);
                        crc = CRC16(buf, 7);
                        buf[7] = crc[1];
                        buf[8] = crc[0];

                        Form1.com.Write(buf, 0, 9);
                    }
                    break;
                case 0x06:
                     byte[] read_w_cmd3 = new byte[8]{ 0x01, 0x06, 0x00, 0x60, 0x00, 0x01, 0x48, 0x14 };
                    Form1.com.Write(read_w_cmd3, 0, 8);
                    break;
            }
        }
        public static void parse_comData(byte[] data,int len)
        {
            bool ret = false;

            for(int i=0;i<len;i++)
            {
                ret = parse_modbus_rtu(ref modbus_data,data[i]);
                if(ret)
                deal_com_cmd(modbus_data);
            }
            
        }
    }


}