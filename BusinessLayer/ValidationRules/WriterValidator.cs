using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public WriterValidator()
        {
            //RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            //RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            //RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz");
            //RuleFor(x => x.WriterMail).Must(Isthere).WithMessage("Bu Mail Adresi Sistemde Kayıtlı");
            RuleFor(x => x.WriterMail).Must(IsPassive).WithMessage("Hesabınız pasif görünüyor lütfen yönetici ile iletişime geçiniz.");
            //RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişini yapın");
            //RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayın.");

        }

        //private bool Isthere(string mail)
        //{

        //    var writermail = writerManager.GetUserByMail(mail);
        //    if (writermail != null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        private bool IsPassive(string mail)
        {
            var writermail = writerManager.GetUserByMail(mail);
            if (writermail.WriterStatus)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
