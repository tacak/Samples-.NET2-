using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalcBusinessApplication.Dto;

namespace CalcBusinessApplication.BizLogic
{
    public class LoginBizLogic
    {
        public void Login(LoginInputDto input)
        {
            if (!"terasoluna".Equals(input.UserId, StringComparison.Ordinal)
               || !"password".Equals(input.Password, StringComparison.Ordinal))
            {
                
            }
        }
    }
}
