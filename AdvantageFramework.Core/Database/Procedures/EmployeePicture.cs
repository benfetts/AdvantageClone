using AdvantageFramework.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


namespace AdvantageFramework.Core.Database.Procedures
{
    public class EmployeePicture
    {
        public static Database.Entities.EmployeePicture LoadByEmployeeCode(AdvantageFramework.Core.Database.DbContext DbContext,string UserCode)
        {
            if (UserCode.StartsWith("externalreviewer"))
            {
                Database.Entities.EmployeePicture fakePicture = new Entities.EmployeePicture();
                string init = UserCode.Split(":")[1].ToUpper();
                Image image = DrawText(init, new Font(FontFamily.GenericSansSerif, 150, FontStyle.Bold), Color.White, Color.FromArgb(0x42,0x8b,0xca));
                fakePicture.EmpImage = ImageToByteArray(image);
                return fakePicture;
            }

            Database.Entities.EmployeePicture employeePicture = (from EmployeePicture in DbContext.EmployeePictures.AsQueryable()
                                                                 join SecUser in DbContext.SecurityUsers on EmployeePicture.EmpCode.ToLower() equals SecUser.EmpCode.ToLower()
                                                                 where SecUser.UserCode.ToLower() == UserCode.ToLower()
                                                                 select EmployeePicture).FirstOrDefault();

            if(employeePicture == null)
            {
                employeePicture = new Entities.EmployeePicture()
                {
                    EmpCode = UserCode.ToLower()
                };
            }

            if (employeePicture != null && employeePicture.EmpImage == null)
            {
                EmployeeCloak employeeCloak = (from EmployeeCloak in DbContext.EmployeeCloaks.AsQueryable()
                                               join SecUser in DbContext.SecurityUsers on EmployeeCloak.EmpCode.ToLower() equals SecUser.EmpCode.ToLower()
                                               where SecUser.UserCode.ToLower() == UserCode.ToLower()
                                               select EmployeeCloak).FirstOrDefault();

                if (employeeCloak != null)
                {
                    string init = employeeCloak.EmpFname.Substring(0,1) + employeeCloak.EmpLname.Substring(0, 1);
                    Image image = DrawText(init, new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular), Color.White, Color.FromArgb(0,188,212));
                    employeePicture.EmpImage = ImageToByteArray(image);
                }
            }

            return employeePicture;
        }

        private static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private static Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);
            SizeF textSize = drawing.MeasureString(text, font);
            img.Dispose();
            drawing.Dispose();
            img = new Bitmap(32, 32);//(int)textSize.Width + 10, (int)textSize.Height + 10);
            drawing = Graphics.FromImage(img);
            drawing.Clear(backColor);
            Brush textBrush = new SolidBrush(textColor);
            drawing.DrawString(text, font, textBrush, 5, 10);
            drawing.Save();
            textBrush.Dispose();
            drawing.Dispose();
            return img;
        }

    }
}
