namespace CourseWork_SAIPIS
{
    public static class mySystem
    {
        public static int CurrUserId{ get; set; } // текущий пользователь системы
        public static string UserStatus { get; set; }

        public static double avgWeight { get; set; } // средняя масса груза
        public static double avgTime { get; set; } // среднее время прохождения
        public static double weightTime { get; set; } // отношение время/груз

    }
}