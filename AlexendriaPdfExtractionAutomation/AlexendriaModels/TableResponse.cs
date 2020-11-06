using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiServicesTestAutomation.modelfiles
{
    public partial class TableResponse
    {
        [JsonProperty("isError")]
        public bool IsError { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }

    public partial class Body
    {
        [JsonProperty("cik")]
        public string Cik { get; set; }

        [JsonProperty("accession_num")]
        public string AccessionNum { get; set; }

        [JsonProperty("form_type")]
        public string FormType { get; set; }

        [JsonProperty("companyname")]
        public string Companyname { get; set; }

        [JsonProperty("filed_date")]
        public string FiledDate { get; set; }

        [JsonProperty("balancesheet_date")]
        public string BalancesheetDate { get; set; }

        [JsonProperty("financial_stmt_rawname")]
        public string FinancialStmtRawname { get; set; }

        [JsonProperty("financial_stmt_name")]
        public string FinancialStmtName { get; set; }

        [JsonProperty("scale")]
        public string Scale { get; set; }

        [JsonProperty("fye")]
        public string Fye { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("page_num")]
        public long PageNum { get; set; }

        [JsonProperty("extraction_accuracy")]
        public double ExtractionAccuracy { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("table")]
        public List<Table> Table { get; set; }
    }

    public partial class Table
    {
        [JsonProperty("lineitem_num")]
        public long? LineitemNum { get; set; }

        [JsonProperty("lineitem_text")]
        public string LineitemText { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("sign")]
        public string Sign { get; set; }

        [JsonProperty("qtrs")]
        public long? Qtrs { get; set; }

        [JsonProperty("month")]
        public long? Month { get; set; }

        [JsonProperty("asofdate")]
        public DateTimeOffset? Asofdate { get; set; }

        [JsonProperty("column_text")]
        public string ColumnText { get; set; }

        [JsonProperty("unit_of_measure")]
        public string UnitOfMeasure { get; set; }

        [JsonProperty("parent")]
        public Parent Parent { get; set; }

        [JsonProperty("footnote")]
        public string Footnote { get; set; }

        [JsonProperty("usgapp_taxonomy_tag")]
        public string UsgappTaxonomyTag { get; set; }

        [JsonProperty("confidence_score")]
        public double? ConfidenceScore { get; set; }

        [JsonProperty("acuity_standard_lineitem_text")]
        public string AcuityStandardLineitemText { get; set; }

        [JsonProperty("acuity_cstore_map")]
        public string AcuityCstoreMap { get; set; }

        [JsonProperty("acuity_statement_id")]
        public string AcuityStatementId { get; set; }

        [JsonProperty("acuity_group_id")]
        public string AcuityGroupId { get; set; }

        [JsonProperty("acuity_line_id")]
        public string AcuityLineId { get; set; }

        [JsonProperty("acuity_parent")]
        public string AcuityParent { get; set; }
    }

    public partial class Parent
    {
        [JsonProperty("parent_1")]
        public string Parent1 { get; set; }
    }
}

    
