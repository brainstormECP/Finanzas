using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Finanzas.Reportes
{
    partial class RegistroAsistencia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.nombreCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.yearLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.fechaLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.mesLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes1Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes2Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes3Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes1Dom1Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes1Dom2Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes1Dom3Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes1Dom4Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes1Dom5Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes2Dom1Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes2Dom2Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes2Dom3Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes2Dom4Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes2Dom5Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes3Dom1Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes3Dom2Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes3Dom3Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes3Dom4Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.mes3Dom5Cell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Encabezado = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.Trimestre = new DevExpress.XtraReports.Parameters.Parameter();
            this.ListaCategoria = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable2.SizeF = new System.Drawing.SizeF(639.0973F, 25F);
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.nombreCell,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // nombreCell
            // 
            this.nombreCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.nombreCell.Name = "nombreCell";
            this.nombreCell.StylePriority.UseBorders = false;
            this.nombreCell.Weight = 1D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Weight = 0.11189188579469087D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Weight = 0.11189189060602384D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Weight = 0.1118918851073597D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Weight = 0.11189188665385852D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Weight = 0.11189188974685627D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Weight = 0.11189188974685621D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Weight = 0.1118918889736068D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Weight = 0.11189188897360676D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Weight = 0.11189188897360679D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Weight = 0.11189188897360683D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Weight = 0.11189188858698206D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Weight = 0.11189188375417318D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Weight = 0.11189188375417318D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Weight = 0.11189188858698204D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Weight = 0.11131056315846315D;
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.yearLabel,
            this.fechaLabel,
            this.mesLabel,
            this.xrLabel2,
            this.xrLabel1});
            this.ReportHeader.HeightF = 87.5F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(178.9583F, 60.75001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(59.375F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Año:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // yearLabel
            // 
            this.yearLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.yearLabel.LocationFloat = new DevExpress.Utils.PointFloat(238.3333F, 60.75001F);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.yearLabel.SizeF = new System.Drawing.SizeF(70.34737F, 23F);
            this.yearLabel.StylePriority.UseFont = false;
            this.yearLabel.StylePriority.UseTextAlignment = false;
            this.yearLabel.Text = "yearLabel";
            this.yearLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // fechaLabel
            // 
            this.fechaLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.fechaLabel.LocationFloat = new DevExpress.Utils.PointFloat(516.6667F, 60.75001F);
            this.fechaLabel.Name = "fechaLabel";
            this.fechaLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fechaLabel.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.fechaLabel.StylePriority.UseFont = false;
            this.fechaLabel.StylePriority.UseTextAlignment = false;
            this.fechaLabel.Text = "fechaLabel";
            this.fechaLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // mesLabel
            // 
            this.mesLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.mesLabel.LocationFloat = new DevExpress.Utils.PointFloat(69.37501F, 60.75001F);
            this.mesLabel.Name = "mesLabel";
            this.mesLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.mesLabel.SizeF = new System.Drawing.SizeF(86.45833F, 23F);
            this.mesLabel.StylePriority.UseFont = false;
            this.mesLabel.StylePriority.UseTextAlignment = false;
            this.mesLabel.Text = "mesLabel";
            this.mesLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 60.75001F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(59.375F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Mes:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(237.5F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(191.6666F, 39.04166F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "IglesiAlDia";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.Encabezado});
            this.PageHeader.HeightF = 88.54167F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.54167F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2});
            this.xrTable1.SizeF = new System.Drawing.SizeF(639.0972F, 50F);
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.mes1Cell,
            this.mes2Cell,
            this.mes3Cell});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Nombres y Apellidos";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            this.xrTableCell1.Weight = 1D;
            // 
            // mes1Cell
            // 
            this.mes1Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes1Cell.Name = "mes1Cell";
            this.mes1Cell.StylePriority.UseFont = false;
            this.mes1Cell.StylePriority.UseTextAlignment = false;
            this.mes1Cell.Text = "Mes 1";
            this.mes1Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes1Cell.Weight = 0.5594592801659074D;
            // 
            // mes2Cell
            // 
            this.mes2Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes2Cell.Name = "mes2Cell";
            this.mes2Cell.StylePriority.UseFont = false;
            this.mes2Cell.StylePriority.UseTextAlignment = false;
            this.mes2Cell.Text = "Mes 2";
            this.mes2Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes2Cell.Weight = 0.55945930490988882D;
            // 
            // mes3Cell
            // 
            this.mes3Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes3Cell.Name = "mes3Cell";
            this.mes3Cell.StylePriority.UseFont = false;
            this.mes3Cell.StylePriority.UseTextAlignment = false;
            this.mes3Cell.Text = "Mes 3";
            this.mes3Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes3Cell.Weight = 0.55945963895363848D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.mes1Dom1Cell,
            this.mes1Dom2Cell,
            this.mes1Dom3Cell,
            this.mes1Dom4Cell,
            this.mes1Dom5Cell,
            this.mes2Dom1Cell,
            this.mes2Dom2Cell,
            this.mes2Dom3Cell,
            this.mes2Dom4Cell,
            this.mes2Dom5Cell,
            this.mes3Dom1Cell,
            this.mes3Dom2Cell,
            this.mes3Dom3Cell,
            this.mes3Dom4Cell,
            this.mes3Dom5Cell});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.Weight = 1D;
            // 
            // mes1Dom1Cell
            // 
            this.mes1Dom1Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes1Dom1Cell.Name = "mes1Dom1Cell";
            this.mes1Dom1Cell.StylePriority.UseFont = false;
            this.mes1Dom1Cell.StylePriority.UseTextAlignment = false;
            this.mes1Dom1Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes1Dom1Cell.Weight = 0.11189188579469087D;
            // 
            // mes1Dom2Cell
            // 
            this.mes1Dom2Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes1Dom2Cell.Name = "mes1Dom2Cell";
            this.mes1Dom2Cell.StylePriority.UseFont = false;
            this.mes1Dom2Cell.StylePriority.UseTextAlignment = false;
            this.mes1Dom2Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes1Dom2Cell.Weight = 0.11189189060602384D;
            // 
            // mes1Dom3Cell
            // 
            this.mes1Dom3Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes1Dom3Cell.Name = "mes1Dom3Cell";
            this.mes1Dom3Cell.StylePriority.UseFont = false;
            this.mes1Dom3Cell.StylePriority.UseTextAlignment = false;
            this.mes1Dom3Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes1Dom3Cell.Weight = 0.1118918851073597D;
            // 
            // mes1Dom4Cell
            // 
            this.mes1Dom4Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes1Dom4Cell.Name = "mes1Dom4Cell";
            this.mes1Dom4Cell.StylePriority.UseFont = false;
            this.mes1Dom4Cell.StylePriority.UseTextAlignment = false;
            this.mes1Dom4Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes1Dom4Cell.Weight = 0.11189188665385852D;
            // 
            // mes1Dom5Cell
            // 
            this.mes1Dom5Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes1Dom5Cell.Name = "mes1Dom5Cell";
            this.mes1Dom5Cell.StylePriority.UseFont = false;
            this.mes1Dom5Cell.StylePriority.UseTextAlignment = false;
            this.mes1Dom5Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes1Dom5Cell.Weight = 0.11189188974685627D;
            // 
            // mes2Dom1Cell
            // 
            this.mes2Dom1Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes2Dom1Cell.Name = "mes2Dom1Cell";
            this.mes2Dom1Cell.StylePriority.UseFont = false;
            this.mes2Dom1Cell.StylePriority.UseTextAlignment = false;
            this.mes2Dom1Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes2Dom1Cell.Weight = 0.11189188974685621D;
            // 
            // mes2Dom2Cell
            // 
            this.mes2Dom2Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes2Dom2Cell.Name = "mes2Dom2Cell";
            this.mes2Dom2Cell.StylePriority.UseFont = false;
            this.mes2Dom2Cell.StylePriority.UseTextAlignment = false;
            this.mes2Dom2Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes2Dom2Cell.Weight = 0.1118918889736068D;
            // 
            // mes2Dom3Cell
            // 
            this.mes2Dom3Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes2Dom3Cell.Name = "mes2Dom3Cell";
            this.mes2Dom3Cell.StylePriority.UseFont = false;
            this.mes2Dom3Cell.StylePriority.UseTextAlignment = false;
            this.mes2Dom3Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes2Dom3Cell.Weight = 0.11189188897360676D;
            // 
            // mes2Dom4Cell
            // 
            this.mes2Dom4Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes2Dom4Cell.Name = "mes2Dom4Cell";
            this.mes2Dom4Cell.StylePriority.UseFont = false;
            this.mes2Dom4Cell.StylePriority.UseTextAlignment = false;
            this.mes2Dom4Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes2Dom4Cell.Weight = 0.11189188897360679D;
            // 
            // mes2Dom5Cell
            // 
            this.mes2Dom5Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes2Dom5Cell.Name = "mes2Dom5Cell";
            this.mes2Dom5Cell.StylePriority.UseFont = false;
            this.mes2Dom5Cell.StylePriority.UseTextAlignment = false;
            this.mes2Dom5Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes2Dom5Cell.Weight = 0.11189188897360683D;
            // 
            // mes3Dom1Cell
            // 
            this.mes3Dom1Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes3Dom1Cell.Name = "mes3Dom1Cell";
            this.mes3Dom1Cell.StylePriority.UseFont = false;
            this.mes3Dom1Cell.StylePriority.UseTextAlignment = false;
            this.mes3Dom1Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes3Dom1Cell.Weight = 0.11189188858698206D;
            // 
            // mes3Dom2Cell
            // 
            this.mes3Dom2Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes3Dom2Cell.Name = "mes3Dom2Cell";
            this.mes3Dom2Cell.StylePriority.UseFont = false;
            this.mes3Dom2Cell.StylePriority.UseTextAlignment = false;
            this.mes3Dom2Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes3Dom2Cell.Weight = 0.11189188375417318D;
            // 
            // mes3Dom3Cell
            // 
            this.mes3Dom3Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes3Dom3Cell.Name = "mes3Dom3Cell";
            this.mes3Dom3Cell.StylePriority.UseFont = false;
            this.mes3Dom3Cell.StylePriority.UseTextAlignment = false;
            this.mes3Dom3Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes3Dom3Cell.Weight = 0.11189188375417318D;
            // 
            // mes3Dom4Cell
            // 
            this.mes3Dom4Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes3Dom4Cell.Name = "mes3Dom4Cell";
            this.mes3Dom4Cell.StylePriority.UseFont = false;
            this.mes3Dom4Cell.StylePriority.UseTextAlignment = false;
            this.mes3Dom4Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes3Dom4Cell.Weight = 0.11189188858698204D;
            // 
            // mes3Dom5Cell
            // 
            this.mes3Dom5Cell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mes3Dom5Cell.Name = "mes3Dom5Cell";
            this.mes3Dom5Cell.StylePriority.UseFont = false;
            this.mes3Dom5Cell.StylePriority.UseTextAlignment = false;
            this.mes3Dom5Cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mes3Dom5Cell.Weight = 0.11189179579705164D;
            // 
            // Encabezado
            // 
            this.Encabezado.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.Encabezado.LocationFloat = new DevExpress.Utils.PointFloat(178.9583F, 0F);
            this.Encabezado.Name = "Encabezado";
            this.Encabezado.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Encabezado.SizeF = new System.Drawing.SizeF(281.25F, 23F);
            this.Encabezado.StylePriority.UseFont = false;
            this.Encabezado.StylePriority.UseTextAlignment = false;
            this.Encabezado.Text = "Registro de Asistencia";
            this.Encabezado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // Trimestre
            // 
            this.Trimestre.Description = "trimestre a mostrar";
            this.Trimestre.Name = "Trimestre";
            this.Trimestre.Type = typeof(short);
            this.Trimestre.ValueInfo = "1";
            // 
            // ListaCategoria
            // 
            this.ListaCategoria.Description = "Parameter1";
            this.ListaCategoria.Name = "ListaCategoria";
            // 
            // RegistroAsistencia
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Trimestre,
            this.ListaCategoria});
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel fechaLabel;
        private DevExpress.XtraReports.UI.XRLabel mesLabel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel yearLabel;
        private DevExpress.XtraReports.UI.XRLabel Encabezado;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell mes1Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes2Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes3Cell;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell mes1Dom1Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes1Dom2Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes1Dom3Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes1Dom4Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes1Dom5Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes2Dom1Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes2Dom2Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes2Dom3Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes2Dom4Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes2Dom5Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes3Dom1Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes3Dom2Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes3Dom3Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes3Dom4Cell;
        private DevExpress.XtraReports.UI.XRTableCell mes3Dom5Cell;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell nombreCell;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        public DevExpress.XtraReports.Parameters.Parameter Trimestre;
        public DevExpress.XtraReports.Parameters.Parameter ListaCategoria;
    }
}
