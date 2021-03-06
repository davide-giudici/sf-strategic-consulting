using System;

namespace StaticVsDynamicDispatchKata.PayTermKata
{
    public class Invoice_Direct
    {
        //... a lot of other fields
        readonly DateTimeOffset date;
        readonly string term;

        public Invoice_Direct(DateTimeOffset date, string term)
        {
            if (String.IsNullOrWhiteSpace(term))
                throw new InvalidTermException();

            this.date = date;
            this.term = term;
        }

        public DateTimeOffset ExpireDate()
        {
            DateTimeOffset result;
            switch (term)
            {
                case "d":
                    result = date;
                    break;
                case "t":
                    result = date.AddDays(30).Date;
                    break;
                case "s":
                    result = date.AddDays(60).Date;
                    break;
                case "n":
                    result = date.AddDays(90).Date;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return result;
        }
    }
}
