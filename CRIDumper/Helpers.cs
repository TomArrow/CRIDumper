using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRIDumper
{
    class Helpers
    {

        public static string byteArrayToString<T>(byte[] input, string separator) where T: unmanaged
        {
            return arrayToString<T>(byteArrayTo<T>(input), separator);
        }

        // Obsolete:
        public static float[] byteArrayToFloats(byte[] input)
        {
            float[] rVal = new float[input.Length / 4];
            for(int i = 0; i < rVal.Length; i++)
            {
                rVal[i] = BitConverter.ToSingle(input, i * 4);
            }
            return rVal;
        }

        // More generic.
        public unsafe static T[] byteArrayTo<T>(byte[] input) where T : unmanaged
        {

            T[] rVal = new T[input.Length / sizeof(T)];
            //for(int i = 0; i < rVal.Length; i++)
            //{
            //    rVal[i] = BitConverter.(input, i * 4);
            //}
            Buffer.BlockCopy(input, 0, rVal, 0, input.Length);
            return rVal;
        }

        public static string arrayToString<T>(T[] input, string separator)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach(T inVal in input)
            {
                if(i++ != 0)
                {

                    sb.Append(separator);
                }
                sb.Append(inVal.ToString());
            }
            return sb.ToString();
        }
    }
}
