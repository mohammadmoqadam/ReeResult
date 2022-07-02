namespace ReeResult
{

  

    public class Result :ResultBase
    {

        public static Result Ok()
        {
            return new Result();
        }

        public  Result AddError(string message)
        {
            base.AddErrorConfig();
            if (Errors == null)
                Errors = new List<string>();
            Errors.Add(message);


            return this;
        }

        public  Result AddReason(string message)
        {
            if (Reasons == null)
                Reasons = new List<string>();
            Reasons.Add(message);

            return this;
        }

    }


}

