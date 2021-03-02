using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    //Static sayesinde newlemek zorunda değiliz.
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarDailyPriceInvalid = "Günlük ücret 0 dan yüksek olmalıdır";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarListed = "Araba listelendi";
        public static string CarDetailsListed = "Araba detayları listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandFound = "Marka bulundu";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorFound = "Renk bulundu";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated= "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string RentalAdded = "Kiralama bilgileri eklendi";
        public static string RentalUpdated = "Kiralama bilgileri güncellendi";
        public static string RentalDeleted = "Kiralama bilgileri silindi";
        public static string RentalsListed = "Kiralama bilgileri listelendi";
        public static string ReturnDateInformation = "Araç henüz teslim edilmedi";
        public static string ReturnDateInformationSuccess = "Araç müsait";
        public static string UpdateReturnDateError = "Araç daha önce teslim edildi.";
        public static string UpdateReturnDateSuccess = "Araç teslim edildi";
        public static string IdNotFound = "Belirttiğiniz id de bir araç yok";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageCountError = "Bir arabaya ait en fazla 5 resim olabilir";
        public static string CarImagesListed = "Araba resimleri listelendi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string UndefinedExtensionError = "Sadece .jpeg , .jpg ve .png uzantılı dosyalar ekleyebilirsiniz";
        public static string CarImageNull = "Lütfen bir araba resmi ekleyiniz";
        public static string AuthorizationDenied = "Yetkiniz yok";
        internal static string UserRegistered = "Kayıt işlemi başarılı";
        internal static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError = "Parola hatalı";
        internal static string SuccessfulLogin = "Giriş işlemi başarılı";
        internal static string UserAlreadyExists = "Kullanıcı mevcut";
        internal static string AccessTokenCreated = "Token oluşturuldu";
    }
}
