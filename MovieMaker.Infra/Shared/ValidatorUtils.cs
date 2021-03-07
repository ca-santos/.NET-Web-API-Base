namespace MovieMaker.Infra.Shared
{
    public static class ValidatorUtils
    {

        public static bool ValidateCpf(this string cpf)
        {

            int[] multiplicatorA = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicatorB = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplicatorA[i];

            int remaining = sum % 11;
            if (remaining < 2)
                remaining = 0;
            else
                remaining = 11 - remaining;

            string digit = remaining.ToString();
            tempCpf += digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplicatorB[i];

            remaining = sum % 11;
            if (remaining < 2)
                remaining = 0;
            else
                remaining = 11 - remaining;

            digit += remaining.ToString();

            return cpf.EndsWith(digit);

        }

    }
}
