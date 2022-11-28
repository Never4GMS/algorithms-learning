namespace Algorithms.Month01.Les05
{
    public static class BitBoard
    {
        public const ulong A = 0x8080808080808080;
        public const ulong H = 0x101010101010101;
        public const ulong _1 = 0xff;

        public const ulong Slash = 0x102040810204080;
        public const ulong SlashUpMask = 0xfefcf8f0e0c08000;
        public const ulong SlashDownMask = 0x103070f1f3f7f;
        public const ulong Backslash = 0x8040201008040201;
        public const ulong BackslashUpMask = 0x7f3f1f0f07030100;
        public const ulong BackslashDownMask = 0x80c0e0f0f8fcfe;

        public static class Negate
        {
            public const ulong A = 0xFeFeFeFeFeFeFeFe;
            public const ulong AB = 0xFcFcFcFcFcFcFcFc;
            public const ulong H = 0x7f7f7f7f7f7f7f7f;
            public const ulong GH = 0x3f3f3f3f3f3f3f3f;
            public const ulong _1 = 0xffffffffffffff;
            public const ulong _8 = 0xffffffffffffff00;
        }
    }
}
