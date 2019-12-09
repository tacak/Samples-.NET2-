using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Terasoluna.Validation.Validators;
using Terasoluna.Windows.ViewModel.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace CalcBusinessApplication.ViewData
{
    [DefaultRuleset("RS01")]
    // [RulesetMapping("RS01", "", "")]
    public class LoginViewData : ValidatableRootViewData
    {
        [DisplayName("ユーザID")]
        [RequiredValidator(Tag = "ユーザID", Ruleset = "RS01")]
        public virtual string UserId { get; set; }

        [DisplayName("パスワード")]
        [RequiredValidator(Tag = "パスワード", Ruleset = "RS01")]
        public virtual string Password { get; set; }
    }
}
