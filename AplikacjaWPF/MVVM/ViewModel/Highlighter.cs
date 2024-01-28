using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using View;

namespace ViewModel
{
    public class Highlighter
    {
        private readonly TextEditor leftTE;
        private readonly TextEditor rightTE;
        private ComparationExecutor comparator;

        public Highlighter(MainWindow mainWindow, ComparationExecutor comparator)
        {
            leftTE = mainWindow.leftTextBox;
            rightTE = mainWindow.rightTextBox;
            this.comparator = comparator;
        }

        public void CompareLines()
        {
            List<string> leftLines = new();
            List<string> rightLines = new();

            Application.Current.Dispatcher.Invoke(() =>
            {
                TextDocument document1 = leftTE.Document;
                TextDocument document2 = rightTE.Document;
                leftLines = document1.Lines.Select(line => document1.GetText(line)).ToList();
                rightLines = document2.Lines.Select(line => document2.GetText(line)).ToList();
            });


                for (int i = 0; i < leftLines.Count; i++)
                {
                    for (int j = 0; j < rightLines.Count; j++)
                    {
                        if (!string.IsNullOrWhiteSpace(leftLines[i].Trim())
                            && !string.IsNullOrWhiteSpace(rightLines[j].Trim())) {
                            if (comparator.ExecuteMainAgorythm(leftLines[i].Trim(), rightLines[j].Trim()) > 0.8) {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    MarkLineSimilarity(i + 1, j + 1);
                                });
                            } 
                        }
                    }
                }
        }

        private void MarkLineSimilarity(int leftLineNo, int rightLineNo)
        {
            DocumentLine leftLine = leftTE.Document.GetLineByNumber(leftLineNo);
            DocumentLine rightLine = rightTE.Document.GetLineByNumber(rightLineNo);

            leftTE.Dispatcher.Invoke(() => HighlightLine(leftTE.TextArea.TextView, leftLine));
            rightTE.Dispatcher.Invoke(() => HighlightLine(rightTE.TextArea.TextView, rightLine));
        }

        private void HighlightLine(TextView textView, DocumentLine line)
        {
            textView.BackgroundRenderers.Add(new LineBackgroundRenderer(line, Brushes.LightGreen));
        }

        private class LineBackgroundRenderer : IBackgroundRenderer
        {
            private readonly DocumentLine line;
            private readonly Brush brush;

            public LineBackgroundRenderer(DocumentLine line, Brush brush)
            {
                this.line = line;
                this.brush = brush;
            }

            public KnownLayer Layer => KnownLayer.Background;

            public void Draw(TextView textView, DrawingContext drawingContext)
            {
                BackgroundGeometryBuilder geoBuilder = new BackgroundGeometryBuilder
                {
                    AlignToWholePixels = true,
                    CornerRadius = 3
                };

                geoBuilder.AddSegment(textView, line);
                Geometry geometry = geoBuilder.CreateGeometry();

                if (geometry != null)
                {
                    drawingContext.DrawGeometry(brush, null, geometry);
                }
            }
        }

        public void ClearColors()
        {
            leftTE.TextArea.TextView.BackgroundRenderers.Clear();
            rightTE.TextArea.TextView.BackgroundRenderers.Clear();
        }

        public void TextChanged([AllowNull] object sender, EventArgs e)
        {
            ClearColors();
        }
    }
}