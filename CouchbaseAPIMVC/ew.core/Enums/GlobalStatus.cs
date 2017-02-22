using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ew.core.Enums
{
    public enum GlobalStatus
    {
        Success,
        UnSuccess,
        Failed,
        Invalid,
        InvalidData,
        Maximum_Limited, // bị giới hạn
        Access_Denied,
        NotFound,
        AlreadyExists,

        HaveNoAnOwner,


        Account_Username_NotFound,

        Account_NotFound,
        Account_Unauthorized,
        Account_IsLocked,
        Account_NotActiveYet,
        Account_IsDeleted,

        Account_Login_FailedManyTime,
        Account_LoginByAuthCode_EmailAlreadyInUse,
        Account_LoginByAuthCode_PhoneAlreadyInUse,

        Account_EmailAlreadyInUse,
        Account_PhoneAlreadyInUse,
        Account_PersonalIdAlreadyInUse,

        Account_ChangePassword_WrongUsernameOrPassword,
        Account_WrongPassword,
        Account_HaveNoPermission,



        Member_CompletedProfile_ProcessedBefore,
        Member_MapAuthCode_ProcessedBefore,
        Member_HappyBirthday_Aldready,

        NotEnoughCoin,

        Exchange_VPoint_NotEnoughCoin,
        Exchange_VCoupon_NotEnoughCoin,

        Campaign_DoAction_OK,
        Campaign_CanNotPlay,
        Campaign_CanNotDoAction,
        Campaign_DoAction_HaveNoPermission,
        Campaign_DoAction_HaveNoPermission_POSAcc,
        Campaign_DoAction_HaveNoAnyPlays,
        Campaign_OutOfGift,
        Campaign_DoAction_Success,
        Campaign_DoAction_UnSuccess,
        Campaign_DoAction_NotEnoughCoin,
        Campaign_DoAction_BeRetrictMinimumCoin,
        Campaign_DoAction_ActionIsUnavailable,
        Campaign_DoAction_BeLimitedMaximumPlayInSession,
        Campaign_DoAction_BeLimitedMaximumPlayInDay,
        Campaign_DoAction_BeLimitedMaximumPlayInCampaign,

        Campaign_SaveDeliveryInfo_UnSuccess,

        Security_Attacker,

        SendSms_InvalidPhone,

        Coupon_InActive,
    }
}
