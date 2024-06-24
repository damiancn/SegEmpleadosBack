namespace Resources.Util
{
    public static class DateUtil
    {
        public static int GetAge(DateTime date)
        {
            var dateSpan = (DateTime.Now.Year - date.Year) - (DateTime.Now.Month < date.Month || (DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day) ? 1 : 0);
            return dateSpan;
        }
    }
}
