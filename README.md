Kod Üretme ve Kontrolünün Sağlanması
----
Hızlı tüketim sektöründe faaliyet gösteren bir gıda firması, ürün ambalajları içerisine kod yerleştirerek, bu kodlar aracılığı ile çeşitli kampanyalar düzenlemek istemektedir. Proje aşağıda kısaca özetlenmiştir.
1. Firma aşağıdaki özelliklere sahip kodlar üretilmesini talep etmektedir.
   -Kodlar 8 hane uzunluğunda ve unique olmalıdır.
   -Kodlar ACDEFGHKLMNPRTXYZ234579 karakter kümesini içermelidir.
3. Kullanıcılar kampanya dönemi içerisinde çeşitli kanallar üzerinden ellerindeki kodları kullanarak kampanyalara katılabilecektir.

Proje Detayları ve Derleme
----
Proje C# dilince yazılmış olup ve .Net 6.0 platformu kullanılarak, console uygulaması oluşturulmuştur. İşlemlerin tamamı Program.cs içerisinde olacak şekilde hazırlanmıştır. Projeyi indirdikten sonra Visual Studio aracılığıyla doğrudan çalıştırabilirsiniz.

Kodun İşlevi
----
Bu kod, belirli bir sayıda benzersiz kod üretmek için tasarlanmıştır. Her bir kod, belirli bir karakter kümesi içinden belirli bir permutasyon algoritmasıyla oluşturulur. Oluşturulan kodlar daha sonra geçerlilik kontrolünden geçirilir ve benzersiz olduğu doğrulandığında bir listeye eklenir.

Adım Adım Analiz
----
Main Metodu: 
--
Programın giriş noktasıdır. Burada, GenerateUniqueCodes metoduna 1000 adet benzersiz kod üretmesi için bir istek yapılır.

GenerateUniqueCodes Metodu:
--
generatedCodes adında bir liste oluşturulur. Bu liste, üretilen benzersiz kodları saklamak için kullanılır.
Bir Random nesnesi oluşturulur.
indices adında bir liste oluşturulur ve bu liste 1 ile 23 arasındaki rastgele sayılarla doldurulur.
GetPermutations metodunu kullanarak, indices listesindeki 8 elemanlı permütasyonları elde eder.
Bu permütasyonlar içinden numCodes sayısı kadar benzersiz kombinasyonlar alınır ve bir liste oluşturulur.
Her bir kombinasyon için bir kod üretilir ve geçerlilik kontrolünden geçirilir. Geçerli ise generatedCodes listesine eklenir.

GenerateCode Metodu:
--
Bir Random nesnesi oluşturulur.
charSet adında bir karakter kümesi tanımlanır. Bu karakter kümesi, oluşturulan kodlarda kullanılacak karakterlerin havuzunu temsil eder.
Kodun başlangıç index'i için bir rastgele değer seçilir.
Permutasyon listesindeki her bir eleman için bir döngü oluşturulur:
Bir sonraki index hesaplanır ve kod oluşturulurken bu index kullanılır.
Oluşturulan karakter kodun sonuna eklenir.
Bir sonraki iterasyon için önceki index güncellenir.

GetPermutations Metodu:
--
list parametresiyle gelen bir listenin elemanlarının belirli bir uzunluktaki permütasyonlarını bulmak için kullanılır.
Eğer permütasyon uzunluğu 1 ise, liste her bir elemanın kendi içinde bir listeye alınmasıyla elde edilir.
Permütasyon uzunluğu 1'den büyükse, rekürsif olarak tüm permütasyonları bulmak için kullanılır.
