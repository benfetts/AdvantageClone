import { ModelBase } from 'models/base/model-base';

export namespace EmployeeExpenseReport {

    export class ExpenseReportDetail extends ModelBase {
        private _itemDate: Date

        ID: number;
        InvoiceNumber: number;
        LineNumber: number;

        get ItemDate(): Date {
            return this._itemDate;
        }
        set ItemDate(value: Date) {
            this._itemDate = this.getShortDate(value);
        }

        Description: string;
        CreditCardFlag: boolean;
        ClientCode: string;
        DivisionCode: string;
        ProductCode: string;
        JobNumber: number;
        JobDescription: string;
        JobComponentNumber: number;
        JobComponentDescription: string;
        FunctionCode: string;
        Quantity: number;
        Rate: number;
        CreditCardAmount: number;
        Amount: number;
        APComment: string;
        CreatedBy: string;
        ModifiedBy: string;
        ModifiedDate: Date;
        PaymentType: number;
        IsImported: boolean;
        NonBillable: boolean;


        constructor() {
            super();
        }

        copyInto(e) {

            this.ID = e.ID;
            this.InvoiceNumber = e.InvoiceNumber;
            this.LineNumber = e.LineNumber;
            this.ItemDate = e.ItemDate;
            this.Amount = e.Amount;
            this.APComment = e.APComment;
            this.ClientCode = e.ClientCode;
            this.CreditCardFlag = e.CreditCardFlag;
            this.Description = e.Description;
            this.DivisionCode = e.DivisionCode;
            this.ProductCode = e.ProductCode;
            this.JobNumber = e.JobNumber;
            this.JobDescription = e.JobDescription;
            this.JobComponentNumber = e.JobComponentNumber;
            this.JobComponentDescription = e.JobComponentDescription;
            this.FunctionCode = e.FunctionCode;
            this.Quantity = e.Quantity;
            this.Rate = e.Rate;
            this.CreditCardAmount = e.CreditCardAmount;
            this.CreatedBy = e.CreatedBy;
            this.ModifiedBy = e.ModifiedBy;
            this.ModifiedDate = e.ModifiedDate;
            this.PaymentType = e.PaymentType;
            this.IsImported = e.IsImported;

        }

    }

    export class ExpenseReport extends ModelBase {

        ApprovedBy: string;
        ApprovedDate: Date;
        ApproverNotes: string;
        BatchDate: Date;
        CreatedBy: string;
        CreatedDate: Date;
        DateFrom: Date;
        DateTo: Date;
        Description: string;
        Details: string;
        EmployeeCode: string;
        EmployeeName: string;
        InvoiceAmount: number;
        InvoiceDate: Date;
        InvoiceNumber: number;
        IsApproved: boolean;
        IsSubmitted: boolean;
        ModifiedBy: string;
        ModifiedDate: Date;
        Status: number;
        StatusCode: string;
        SubmittedTo: string;
        VendorCode: string;
        TotalNonBillable: number;
        TotalBillable: number;
        TotalAmount: number;
        Paid: boolean;

        ExpenseReportDetails: ExpenseReportDetail[];

        constructor() {
            super();
        }

    }

    export enum ExpenseReportStatus {
        Open = 0,
        Pending = 1,
        Approved = 2,
        PendingApproval = 3,
        DeniedByApprover = 4,
        ApprovedByApprover = 5,
        ApprovedInAccounting = 6,
        PendingApprovalInAccounting = 7,
        DeniedByAccounting = 8
    }

    export enum ApprovedFlag {
        Pending = 0,
        Denied = 1,
        Approved = 2
    }
}
