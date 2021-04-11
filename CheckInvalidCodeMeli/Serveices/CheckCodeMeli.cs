using System;
using System.Collections.Generic;
//=================================

public class CheckCodeMeliClass
{
    private List<IndexVM> ResultList;
    //################################
    public List<IndexVM> GetInvalidList(List<IndexVM> fOstadList_amozeshDb, List<IndexVM> Os_tbList_thesesDb)
    {
        ResultList = new List<IndexVM>();
        foreach (var item1 in fOstadList_amozeshDb)
        {
            if (!IsValidCodeMeli(item1.CodeMeli))
                ResultList.Add(item1);
        }

        foreach (var item2 in Os_tbList_thesesDb)
        {
            if (!IsValidCodeMeli(item2.CodeMeli))
                ResultList.Add(item2);
        }

        return ResultList;
    }

    //################################
    private bool IsValidCodeMeli(string codeMeli)
    {
        try
        {
            if (codeMeli.Length != 10)
                return false;
            if (!this.IsNumeric(codeMeli))
                return false;
            int a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a, b;
            int sum, mm;
            char[] code = new char[12];
            if (codeMeli == "1111111111" || codeMeli == "2222222222" ||
                          codeMeli == "3333333333" || codeMeli == "4444444444" ||
                          codeMeli == "5555555555" || codeMeli == "6666666666" ||
                          codeMeli == "7777777777" || codeMeli == "8888888888" ||
                          codeMeli == "9999999999" || codeMeli == "0000000000")
                return false;
            code = codeMeli.ToCharArray();

            a1 = Convert.ToInt32(code[0].ToString()) * 10;
            a2 = Convert.ToInt32(code[1].ToString()) * 9;
            a3 = Convert.ToInt32(code[2].ToString()) * 8;
            a4 = Convert.ToInt32(code[3].ToString()) * 7;
            a5 = Convert.ToInt32(code[4].ToString()) * 6;
            a6 = Convert.ToInt32(code[5].ToString()) * 5;
            a7 = Convert.ToInt32(code[6].ToString()) * 4;
            a8 = Convert.ToInt32(code[7].ToString()) * 3;
            a9 = Convert.ToInt32(code[8].ToString()) * 2;
            //------------------
            a10 = Convert.ToInt32(code[9].ToString());//رقم اخر

            sum = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9;
            mm = (sum % 11);
            if (mm < 2)
                if (a10 == mm)
                    return true;
            if (mm >= 2)
                if ((11 - mm) == a10)
                    return true;
            return false;
        }
        catch
        {
            return false;
        }

    }


    //################################
    private bool IsNumeric(string codeMeli)
    {
        decimal outPut;
        var Result = decimal.TryParse(codeMeli, out outPut);
        return Result == true ? true : false;
    }


    //################################
}
