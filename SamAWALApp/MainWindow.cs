using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CsvHelper;
using PdfSharp.Pdf;
using System.IO;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace SamAWALApp
{
    public partial class Form1 : Form
    {
        public class RecordingRights
        {
            public string STATEMENT_PERIOD { get; set; }
            public string AGREEMENT_ID { get; set; }
            public string INCOMING_BATCH_ID { get; set; }
            public string INCOMING_BATCH_SOURCE_NAME { get; set; }
            public string INCOMING_BATCH_DESCRIPTION { get; set; }
            public string TRACKBUNDLE { get; set; }
            public string BUNDLE_ID { get; set; }
            public string AWAL_BUNDLE_ID { get; set; }
            public string BUNDLE_TITLE { get; set; }
            public string BUNDLE_VERSION_SUB_TITLE { get; set; }
            public string BUNDLE_ARTIST { get; set; }
            public string BUNDLE_UPC_EAN { get; set; }
            public string BUNDLE_CATALOGUE_NUMBER { get; set; }
            public string TRACK_ID { get; set; }
            public string AWAL_TRACK_ID { get; set; }
            public string TRACK_ISRC { get; set; }
            public string TRACK_TITLE { get; set; }
            public string TRACK_SUBTITLE { get; set; }
            public string TRACK_ARTIST { get; set; }
            public string AUDIOVIDEO { get; set; }
            public string LABEL { get; set; }
            public string USE_TYPE { get; set; }
            public string COMMERCIAL_MODEL_TYPE { get; set; }
            public string YOUTUBE_CONTENT_TYPE { get; set; }
            public string TERRITORY_OF_SALE_CODE { get; set; }
            public string TERRITORY_OF_SALE { get; set; }
            public string TERRITORY_OF_DISTRIBUTION_CODE { get; set; }
            public string TERRITORY_OF_DISTRIBUTION { get; set; }
            public string ROYALTY_PERIOD_START_DATE { get; set; }
            public string ROYALTY_PERIOD_END_DATE { get; set; }
            public string PERCENTAGE_PAID { get; set; }
            public string QUANTITY_SUM { get; set; }
            public string INCOMING_BATCH_CCY { get; set; }
            public string EXCHANGE_RATE { get; set; }
            public string AGREEMENT_CCY { get; set; }
            public string PPD { get; set; }
            public string REVENUE { get; set; }
            public string COMMISSION_PERCENTAGE { get; set; }
            public string COMMISSION_AMOUNT { get; set; }
            public string SHARED_DIST_FEE_PERCENTAGE { get; set; }
            public string DISTRIBUTED_AMOUNT { get; set; }
            public string INCLUDES_MECHANICALS { get; set; }
            public string TYPE { get; set; }
        }

        public sealed class RecordingRightsMap : CsvHelper.Configuration.ClassMap<RecordingRights>
        {
            public RecordingRightsMap()
            {
                AutoMap();
                Map(m => m.TRACKBUNDLE).Name("TRACK/BUNDLE");
                Map(m => m.AUDIOVIDEO).Name("AUDIO / VIDEO");
            }
        }

        public class Collection
        {
            public List<RecordingRights> recordingRights = new List<RecordingRights>();
            public double distributedAmount = 0.0d;
        }

        public class DistributedAmountClass
        {
            public string TrackBundle { get; set; }
            public string ISRC { get; set; }
            public string TrackTitle { get; set; }
            public string TrackSubtitle { get; set; }
            public string DistributedAmount { get; set; }
            public string Label { get; set; }
            public string TrackArtist { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            addScrollbarToPanel(runningTotalBoxTracks);
            addScrollbarToPanel(runningTotalBoxBundles);

            ContextMenu trackContextMenu = new ContextMenu();
            trackContextMenu.MenuItems.Add("Copy running total to clipboard", delegate { Clipboard.SetText(runningTotalBoxTracks.Text.Replace("Tracks Running Total: ", "")); });
            runningTotalBoxTracks.ContextMenu = trackContextMenu;

            ContextMenu bundleContextMenu = new ContextMenu();
            bundleContextMenu.MenuItems.Add("Copy running total to clipboard", delegate { Clipboard.SetText(runningTotalBoxBundles.Text.Replace("Bundles Running Total: ", "")); });
            runningTotalBoxBundles.ContextMenu = bundleContextMenu;
        }

        private void addScrollbarToPanel(Panel p)
        {
            p.AutoScroll = false;
            p.HorizontalScroll.Enabled = false;
            p.HorizontalScroll.Visible = false;
            p.HorizontalScroll.Maximum = 0;
            p.AutoScroll = true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog() { Filter = "CSV files (*.csv)|*.csv", Title = "Import a .csv file....", Multiselect = false };
            dialog.ShowDialog();
            string filePath = dialog.FileName;

            importCSV(filePath);
        }

        private void importCSV(string filePath)
        {
            runningTotalBoxTracks.Controls.Clear();
            runningTotalBoxBundles.Controls.Clear();
            recordingRightsBindingSource.Clear();
            distributedAmountClassBindingSource.Clear();

            labelFilename.Text = "Current file: " + Path.GetFileNameWithoutExtension(filePath).Replace('_', ' ');

            try
            {
                TextReader importedFile = new StreamReader(@filePath);
                parseCSVFile(new CsvReader(importedFile));
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please select a file.", "Nothing Selected....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void parseCSVFile(CsvReader csv)
        {
            Dictionary<string, Collection> entries = new Dictionary<string, Collection>(); // Set up the 'entries' Dict that will become the second table's data //

            csv.Configuration.RegisterClassMap<RecordingRightsMap>();
            while (csv.Read())
            {
                var record = csv.GetRecord<RecordingRights>();
                if (record.TRACKBUNDLE == "Track")
                {
                    if (entries.ContainsKey(record.TRACK_ISRC)) entries[record.TRACK_ISRC].recordingRights.Add(record); // If the ISRC already exists, add it to the entry's list attribute //
                    else
                    {
                        entries.Add(record.TRACK_ISRC, new Collection());
                        entries[record.TRACK_ISRC].recordingRights.Add(record);
                    }
                } else
                {
                    if (entries.ContainsKey(record.BUNDLE_ID)) entries[record.BUNDLE_ID].recordingRights.Add(record); // If someone bought the bundle not the track it needs to be added to something seperately //
                    else
                    {
                        entries.Add(record.BUNDLE_ID, new Collection());
                        entries[record.BUNDLE_ID].recordingRights.Add(record);
                    }
                }
            }

            int yValTracks = 5;
            int yValBundles = 5;

            foreach (var item in entries)
            {
                foreach (var entry in item.Value.recordingRights)
                {
                    item.Value.distributedAmount += double.Parse(entry.DISTRIBUTED_AMOUNT);
                }

                DistributedAmountClass distributedAmount = new DistributedAmountClass()
                {
                    TrackBundle = item.Value.recordingRights[0].TRACKBUNDLE,
                    DistributedAmount = "£" + item.Value.distributedAmount.ToString(),
                    ISRC = item.Key,
                    TrackTitle = item.Value.recordingRights[0].TRACK_TITLE,
                    TrackSubtitle = item.Value.recordingRights[0].TRACK_SUBTITLE,
                    TrackArtist = item.Value.recordingRights[0].TRACK_ARTIST,
                    Label = item.Value.recordingRights[0].LABEL
                };

                if(distributedAmount.TrackBundle == "Bundle")
                {
                    distributedAmount.TrackArtist = item.Value.recordingRights[0].BUNDLE_ARTIST;
                    distributedAmount.TrackTitle = item.Value.recordingRights[0].BUNDLE_TITLE;
                    distributedAmount.TrackSubtitle = item.Value.recordingRights[0].BUNDLE_VERSION_SUB_TITLE;

                    CheckBox checkBox = new CheckBox()
                    {
                        AutoSize = true,
                        Text = distributedAmount.ISRC + " - " + distributedAmount.TrackArtist + " - " + distributedAmount.TrackTitle,
                        Location = new System.Drawing.Point(5, yValBundles),
                        Tag = distributedAmount.DistributedAmount.ToString().Replace('£', ' ').Trim(),
                        UseMnemonic = false
                    };
                    if(distributedAmount.TrackSubtitle != "") checkBox.Text += " (" + distributedAmount.TrackSubtitle + ")";

                    checkBox.CheckStateChanged += delegate {
                        bool exportSelectedEnabled = false;
                        foreach (CheckBox c in runningTotalBoxTracks.Controls) if (c.Checked) exportSelectedEnabled = true;
                        foreach (CheckBox c in runningTotalBoxBundles.Controls) if (c.Checked) exportSelectedEnabled = true;
                        btnExportSelected.Enabled = exportSelectedEnabled;
                    };
                    runningTotalBoxBundles.Controls.Add(checkBox);
                    yValBundles += checkBox.Height;
                } else
                {
                    CheckBox checkBox = new CheckBox()
                    {
                        AutoSize = true,
                        Text = distributedAmount.ISRC + " - " + distributedAmount.TrackArtist + " - " + distributedAmount.TrackTitle,
                        Location = new System.Drawing.Point(5, yValTracks),
                        Tag = distributedAmount.DistributedAmount.ToString().Replace('£', ' ').Trim(),
                        UseMnemonic = false
                    };
                    if (distributedAmount.TrackSubtitle != "")
                    {
                        checkBox.Text += " (" + distributedAmount.TrackSubtitle + ")";
                    }

                    checkBox.CheckStateChanged += delegate {
                        bool exportSelectedEnabled = false;
                        foreach (CheckBox c in runningTotalBoxTracks.Controls)
                        {
                            if (c.Checked)
                            {
                                exportSelectedEnabled = true;
                            }
                        }
                        foreach (CheckBox c in runningTotalBoxBundles.Controls)
                        {
                            if (c.Checked)
                            {
                                exportSelectedEnabled = true;
                            }
                        }
                        btnExportSelected.Enabled = exportSelectedEnabled;
                    };
                    runningTotalBoxTracks.Controls.Add(checkBox);
                    yValTracks += checkBox.Height;
                }

                distributedAmountClassBindingSource.Add(distributedAmount);
            }

            distributedAmountDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); // To make the table auto-sized //

            btnPDF.Enabled = true;
        }


        private void btnPDF_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            string[] s = labelFilename.Text.Replace("Current file: ", "").Split(' ');
            string dateRange = s[0] + " " + s[1] + " " + s[2].Replace("-", " - ") + " " + s[3] + " " + s[4]; // I'm so sorry for this, so help me god //

            try
            {
                gfx.DrawString("Recording Rights: " + dateRange, new XFont("Open Sans", 15, XFontStyle.Bold), XBrushes.Black,
                new XRect(0, 0, page.Width, 50),
                XStringFormats.Center);
            } catch (Exception)
            {
                gfx.DrawString("Recording Rights", new XFont("Open Sans", 15, XFontStyle.Bold), XBrushes.Black,
                new XRect(0, 0, page.Width, 50),
                XStringFormats.Center);
            }

            int yVal = 30;

            gfx.DrawString("Tracks", new XFont("Open Sans", 15, XFontStyle.BoldItalic), XBrushes.DarkRed, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);

            yVal += 20;
            double total = 0.0d;

            bool bundles = false;
            foreach (DataGridViewRow entry in distributedAmountDataGrid.Rows) // Tracks //
            {
                if(entry.Cells[6].Value.ToString() == "Track")
                {
                    // Track Title & Subtitle //
                    if (entry.Cells[3].Value.ToString() != "")
                    {
                        gfx.DrawString(entry.Cells[1].Value.ToString() + " - " + entry.Cells[2].Value.ToString() + " (" + entry.Cells[3].Value.ToString() + ")", new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                    }
                    else
                    {
                        gfx.DrawString(entry.Cells[1].Value.ToString() + " - " + entry.Cells[2].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                    }

                    // ISRC //
                    gfx.DrawString(entry.Cells[0].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Italic), XBrushes.Black, new XRect(-15, yVal, page.Width, 50), XStringFormats.CenterRight);

                    // Label //
                    gfx.DrawString(entry.Cells[5].Value.ToString(), new XFont("Open Sans", 8, XFontStyle.Regular), XBrushes.Black, new XRect(-15, yVal + 10, page.Width, 50), XStringFormats.CenterRight);

                    // Distributed Amount //
                    gfx.DrawString(entry.Cells[4].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Italic), XBrushes.Black, new XRect(35, yVal + 15, page.Width, 50), XStringFormats.CenterLeft);

                    yVal += 35;

                    gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkRed)), 0, yVal - 20, page.Width, yVal - 20);

                    // Add to total //
                    total += double.Parse(entry.Cells[4].Value.ToString().Replace('£', ' ').Trim());
                } else
                {
                    bundles = true;
                }
            }
            gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkRed)), 0, yVal + 15, page.Width, yVal + 15);

            yVal += 15;
            gfx.DrawString("Bundles", new XFont("Open Sans", 15, XFontStyle.BoldItalic), XBrushes.DarkBlue, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
            yVal += 20;

            if (bundles)
            {
                foreach (DataGridViewRow entry in distributedAmountDataGrid.Rows) // Bundles //
                {
                    if (entry.Cells[6].Value.ToString() == "Bundle")
                    {
                        // Track Title & Subtitle //
                        if (entry.Cells[3].Value.ToString() != "")
                        {
                            gfx.DrawString(entry.Cells[1].Value.ToString() + " - " + entry.Cells[2].Value.ToString() + " (" + entry.Cells[3].Value.ToString() + ")", new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                        }
                        else
                        {
                            gfx.DrawString(entry.Cells[1].Value.ToString() + " - " + entry.Cells[2].Value.ToString(), new XFont("Verdana", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                        }

                        // ISRC //
                        gfx.DrawString(entry.Cells[0].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Italic), XBrushes.Black, new XRect(-15, yVal, page.Width, 50), XStringFormats.CenterRight);

                        // Label //
                        gfx.DrawString(entry.Cells[5].Value.ToString(), new XFont("Open Sans", 8, XFontStyle.Regular), XBrushes.Black, new XRect(-15, yVal + 10, page.Width, 50), XStringFormats.CenterRight);

                        // Distributed Amount //
                        gfx.DrawString(entry.Cells[4].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Italic), XBrushes.Black, new XRect(35, yVal + 15, page.Width, 50), XStringFormats.CenterLeft);

                        yVal += 35;

                        gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkBlue)), 0, yVal - 20, page.Width, yVal - 20);

                        // Add to total //
                        total += double.Parse(entry.Cells[4].Value.ToString().Replace('£', ' ').Trim());
                    }
                }
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkBlue)), 0, yVal + 15, page.Width, yVal + 15);
            } else
            {
                gfx.DrawString("No bundles to display", new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkBlue)), 0, yVal + 15, page.Width, yVal + 15);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkBlue)), 0, yVal + 35, page.Width, yVal + 35);
            }

            // Total //
            gfx.DrawString("Total: £" + total.ToString(), new XFont("Open Sans", 15, XFontStyle.Bold), XBrushes.Black, new XRect(-15, yVal + 50, page.Width, 50), XStringFormats.CenterRight);

            try
            {
                string filename = "RecordingRights_" + dateRange.Replace(' ', '_') + ".pdf";
                document.Save(filename);
                Process.Start(filename);
            } catch (Exception)
            {
                string filename = "RecordingRights_" + DateTime.Now.ToFileTimeUtc().ToString() + ".pdf";
                document.Save(filename);
                Process.Start(filename);
            }
        }

        private void btnExportSelected_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            string[] s = labelFilename.Text.Replace("Current file: ", "").Split(' ');
            string dateRange = s[0] + " " + s[1] + " " + s[2] + " " + s[3] + " " + s[4]; // I'm so sorry for this, so help me god //

      
            gfx.DrawString("Showing Selected Recording Rights: ", new XFont("Open Sans", 15, XFontStyle.Bold), XBrushes.Black,
                new XRect(0, 0, page.Width, 50),
                XStringFormats.Center);

            int yVal = 30;

            gfx.DrawString("Tracks", new XFont("Open Sans", 15, XFontStyle.BoldItalic), XBrushes.DarkRed, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);

            yVal += 20;
            double total = 0.0d;
            int i = 0;

            bool tracks = false;
            foreach (CheckBox c in runningTotalBoxTracks.Controls)
            {
                if (c.Checked)
                {
                    tracks = true;
                }
            }

            if(tracks)
            {
                foreach (CheckBox c in runningTotalBoxTracks.Controls)
                {
                    if (c.Checked)
                    {
                        DataGridViewRow entry = null;

                        foreach (DataGridViewRow row in distributedAmountDataGrid.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == c.Text.Split(' ')[0].Trim())
                            {
                                entry = row;
                            }
                        }

                        // Track Title & Subtitle //
                        if (entry.Cells[3].Value.ToString() != "")
                        {
                            gfx.DrawString(entry.Cells[1].Value.ToString() + " - " + entry.Cells[2].Value.ToString() + " (" + entry.Cells[3].Value.ToString() + ")", new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                        }
                        else
                        {
                            gfx.DrawString(entry.Cells[1].Value.ToString() + " - " + entry.Cells[2].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                        }

                        // ISRC //
                        gfx.DrawString(entry.Cells[0].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Italic), XBrushes.Black, new XRect(-15, yVal, page.Width, 50), XStringFormats.CenterRight);

                        // Label //
                        gfx.DrawString(entry.Cells[5].Value.ToString(), new XFont("Open Sans", 8, XFontStyle.Regular), XBrushes.Black, new XRect(-15, yVal + 10, page.Width, 50), XStringFormats.CenterRight);

                        // Distributed Amount //
                        gfx.DrawString(entry.Cells[4].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Italic), XBrushes.Black, new XRect(35, yVal + 15, page.Width, 50), XStringFormats.CenterLeft);

                        yVal += 35;

                        gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkRed)), 0, yVal - 20, page.Width, yVal - 20);

                        // Add to total //
                        total += double.Parse(entry.Cells[4].Value.ToString().Replace('£', ' ').Trim());
                    }

                    i++;
                }
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkRed)), 0, yVal + 15, page.Width, yVal + 15);
            } else
            {
                gfx.DrawString("No tracks to display", new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkRed)), 0, yVal + 15, page.Width, yVal + 15);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkRed)), 0, yVal + 35, page.Width, yVal + 35);
                yVal += 15;
            }

            yVal += 15;
            gfx.DrawString("Bundles", new XFont("Open Sans", 15, XFontStyle.BoldItalic), XBrushes.DarkBlue, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
            yVal += 20;

            bool bundles = false;
            foreach (CheckBox c in runningTotalBoxBundles.Controls)
            {
                if(c.Checked)
                {
                    bundles = true;
                }
            }

            i = 0;
            if (bundles)
            {
                foreach (CheckBox c in runningTotalBoxBundles.Controls)
                {
                    if (c.Checked)
                    {
                        DataGridViewRow entry = null;

                        foreach (DataGridViewRow row in distributedAmountDataGrid.Rows)
                        {
                            if(row.Cells[0].Value.ToString() == c.Text.Split(' ')[0].Trim())
                            {
                                entry = row;
                            }
                        }

                        // Track Title & Subtitle //
                        if (entry.Cells[3].Value.ToString() != "")
                        {
                            gfx.DrawString(entry.Cells[1].Value.ToString() + " - " + entry.Cells[2].Value.ToString() + " (" + entry.Cells[3].Value.ToString() + ")", new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                        }
                        else
                        {
                            gfx.DrawString(entry.Cells[1].Value.ToString() + " - " + entry.Cells[2].Value.ToString(), new XFont("Verdana", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                        }

                        // ISRC //
                        gfx.DrawString(entry.Cells[0].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Italic), XBrushes.Black, new XRect(-15, yVal, page.Width, 50), XStringFormats.CenterRight);

                        // Label //
                        gfx.DrawString(entry.Cells[5].Value.ToString(), new XFont("Open Sans", 8, XFontStyle.Regular), XBrushes.Black, new XRect(-15, yVal + 10, page.Width, 50), XStringFormats.CenterRight);

                        // Distributed Amount //
                        gfx.DrawString(entry.Cells[4].Value.ToString(), new XFont("Open Sans", 11, XFontStyle.Italic), XBrushes.Black, new XRect(35, yVal + 15, page.Width, 50), XStringFormats.CenterLeft);

                        yVal += 35;

                        gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkBlue)), 0, yVal - 20, page.Width, yVal - 20);

                        // Add to total //
                        total += double.Parse(entry.Cells[4].Value.ToString().Replace('£', ' ').Trim());
                    }
                }
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkBlue)), 0, yVal + 15, page.Width, yVal + 15);
            }
            else
            {
                gfx.DrawString("No bundles to display", new XFont("Open Sans", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, yVal, page.Width, 50), XStringFormats.CenterLeft);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkBlue)), 0, yVal + 15, page.Width, yVal + 15);
                gfx.DrawLine(new XPen(XColor.FromKnownColor(XKnownColor.DarkBlue)), 0, yVal + 35, page.Width, yVal + 35);
            }

            // Total //
            gfx.DrawString("Total: £" + total.ToString(), new XFont("Open Sans", 15, XFontStyle.Bold), XBrushes.Black, new XRect(-15, yVal + 50, page.Width, 50), XStringFormats.CenterRight);

            try
            {
                string filename = "SelectedRecordingRights_" + dateRange.Replace(' ', '_') + ".pdf";
                document.Save(filename);
                Process.Start(filename);
            }
            catch (Exception)
            {
                string filename = "SelectedRecordingRights_" + DateTime.Now.ToFileTimeUtc().ToString() + ".pdf";
                document.Save(filename);
                Process.Start(filename);
            }
        }
    }
}
