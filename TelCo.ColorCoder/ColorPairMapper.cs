using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    class ColorPairMapper
    {
        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = ColorMapper.colorMapMinor.Length;
            int majorSize = ColorMapper.colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize){
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }
            
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            ColorPair pair = new ColorPair() { majorColor = ColorMapper.colorMapMajor[majorIndex],
                minorColor = ColorMapper.colorMapMinor[minorIndex] };

            return pair;
        }

        public static int GetPairNumberFromColor(ColorPair pair){
            int majorIndex = -1;
            for (int i = 0; i < ColorMapper.colorMapMajor.Length; i++){
                if (ColorMapper.colorMapMajor[i] == pair.majorColor){
                    majorIndex = i;
                    break;
                }
            }
            int minorIndex = -1;
            for (int i = 0; i < ColorMapper.colorMapMinor.Length; i++){
                if (ColorMapper.colorMapMinor[i] == pair.minorColor){
                    minorIndex = i;
                    break;
                }
            }
            if (majorIndex == -1 || minorIndex == -1){
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorIndex * ColorMapper.colorMapMinor.Length) + (minorIndex + 1);
        }
    }
}    