using iTextSharp.text;
using iTextSharp.text.pdf;

using Microsoft.Extensions.Configuration;

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Up4All.Tasker.Framework.Contracts;
using Up4All.Tasker.Framework.Entities;
using Up4All.Tasker.Framework.Entities.Enums;
using Up4All.Tasker.Framework.ViewModels;

using Image = System.Drawing.Image;

namespace Up4All.Tasker.Framework.ApiClients.Mocks
{
    public class TaskServiceMock : ITaskService
    {   

        public TaskServiceMock()
        {            
        }

        public string CleanAccents(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public Stream GeneratePdf(Image img)
        {
            var pdf = new Document(PageSize.A4);

            var str = new MemoryStream();
            var writer = PdfWriter.GetInstance(pdf, str);
            pdf.Open();

            var pimg = iTextSharp.text.Image.GetInstance(img, BaseColor.White);
            var prop = pimg.PlainHeight / pimg.PlainWidth;
            pimg.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height * prop);
            pimg.SetAbsolutePosition(0, PageSize.A4.Height - pimg.ScaledHeight);
            writer.DirectContent.AddImage(pimg);
            pdf.Close();

            return str;
        }

        public bool CompareName(string sourceName, string contextName)
        {
            sourceName = CleanAccents(sourceName.ToUpper());
            contextName = CleanAccents(contextName.ToUpper());

            var splnome = sourceName.ToUpper().Split(' ');
            var splFullname = contextName.Split(' ');

            var intA = splnome.Except(splFullname);
            var intB = splFullname.Except(splnome);

            return !intA.Any() && !intB.Any();
        }

        public Task SaveAsync(Context context)
        {
            if (context.Result == null || context.Result.Status == TaskResultEnum.None)
                context.Result.SetAsFailed();

            return Task.CompletedTask;
        }
    }
}
