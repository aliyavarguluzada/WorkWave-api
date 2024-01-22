using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Domain.Enums
{
    public enum ErrorCodesEnum
    {
        [Description("User already exists")]
        User_Already_Exists = 1_0_1,

        [Description("Email is not correct")]
        Email_Is_Not_Correct = 1_0_2,

        [Description("Password is not correct")]
        Password_Is_Not_Correct = 1_0_3,

        [Description("ConfirmPassword does not match")]
        ConfirmPassword_Does_Not_Match = 1_0_4, 

        [Description("Username is Empty")]
        Username_Is_Empty = 1_0_5,

        [Description("Some Error")]
        Some_Error = 1_0_0_1,

        [Description("User not Found")]
        User_Not_Found = 4_0_4,

        [Description("Internal server error occured")]
        INTERNAL_SERVER_ERROR = 5_0_0,

    }
}
