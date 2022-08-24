namespace TBC.OpenAPI.SDK.OnlineInstallments.Models.Responses
{
    public enum ApplicationStatuses
    {
        /// <summary>
        /// Installment pending for client authentication in TBC Bank
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Installment is In Progress
        /// </summary>
        InProgress = 1,

        /// <summary>
        ///Installment was Approved by TBC Bank
        /// </summary>
        Approved = 2,

        /// <summary>
        ///Installment was expired
        /// </summary>
        Expired = 3,

        /// <summary>
        /// Installment was Canceled
        /// </summary>
        Canceled = 4,

        /// <summary>
        /// Installment is Waiting For Merchant Decision (Approve/Cancel)
        /// </summary>
        WaitingForMerchant = 5,

        /// <summary>
        /// Installment was Declined by TBC Bank
        /// </summary>
        Declined = 6,

        /// <summary>
        /// Installment was Canceled By Merchant
        /// </summary>
        CanceledByMerchant = 7,

        /// <summary>
        /// Installment was Disbursed (Confirmed from both side)
        /// </summary>
        Disbursed = 8,

        /// <summary>
        /// Installment pending Disbursed (Confirmed from both side)
        /// </summary>
        PendingDisbursed = 9,

        /// <summary>
        /// Installment need confirmation of renewed contract by the client
        /// </summary>
        NeedConfirmation = 10,

        /// <summary>
        /// Installment is Waiting For Income Documents Upload
        /// </summary>
        WaitingForIncomeDocumentsUpload = 11,

        /// <summary>
        /// Installment is Waiting For Income Documents Verification
        /// </summary>
        WaitingForIncomeDocumentsVerification = 12,

        /// <summary>
        /// Income Document(s) Declined
        /// </summary>
        DocumentDeclined = 13
    }
}
