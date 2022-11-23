# Generator

# İçindekiler

[Ana Ekran 1](#_Toc120051356)

[Service Method Add Ekranı 3](#_Toc120051357)

[Parameter and Result Add Ekranı 3](#_Toc120051358)

[UX Generator 4](#_Toc120051359)

[Header Create 4](#_Toc120051360)

[Content 4](#_Toc120051361)

[Grid Create 5](#_Toc120051362)

[Grid Service 6](#_Toc120051363)

[File Export 7](#_Toc120051364)

[Action, String, Page, Menu Option 8](#_Toc120051365)

[One Service 9](#_Toc120051366)

[Events 10](#_Toc120051367)

# Ana Ekran

**Ekranın açılması uzun sürecektir.**

![](RackMultipart20221123-1-ssx3ak_html_d8a62ebe85653487.png)

**Search** : Comboboxlardan seçilen değere göre Object listeleniyor. Veriler OBJECT tablosundan çekiliyor.

**Selected Data** : Gridden seçilen datanın verileriyle dolduruluyor. Bu alanların doluluğu sağlanıyorsa **Utilities** bölümündeki ekleme ekranlarına erişim sağlanabiliniyor.

Aşşağıdaki resmi inceleyebilirsiniz.

![](RackMultipart20221123-1-ssx3ak_html_43c715382efa3722.png)

**Service Method Add** : Seçilen object için SERVİCE\_METHODS talosuna kayıt atmak için kullanılır.

**Parameter And Result Add** : Seçilen object in ORACLE\_TEXT kolonunda bulunan sql sorgusunu kullanarak result ve parameter bulup databasede OBJECT\_RESULTS ve OBJECT\_PARAMETERS tablosuna eklemek için kullanılır.

**UX Generator** : Generat işlemlerinin yapıldığı ekranı açar.

# Service Method Add Ekranı

![](RackMultipart20221123-1-ssx3ak_html_aa7d99bf8b3f311e.png)

**Add Service Method To Database** : Gridde bulunan satırı veritabanına ekler. Veri tabnında aynı kayıttan bulunuyorsa hiçbirşey yapmıyacaktır.

**Override Add** : Gridde bulunan satırı veritabanına ekle. Veri tabınında aynı kayıttan bulunuyorsa ezererek yeni kayıt ekler.

**Service Method List :** Veritabanından griddeki değerelere göre arama yapar. Kayıt bulunuyorsa listeler.

# Parameter and Result Add Ekranı

![](RackMultipart20221123-1-ssx3ak_html_66f5cec6b140d795.png)

**Parameter Find :** Ana ekrandan seçilen Objectin ORACLE\_TEXT değerinden parametreleri bulur.

**Add Parameters to Database :** Gridde listelenen parametreleri veritabanında OBJECT\_PARAMETERS tablosunu ekler.

**Parameter List** : Objecte ait parametreleri veritanından çeker.

Yukarıdaki metodlar Result için de aynen geçerlidir.

# UX Generator

Xml ve javascriptin oluşturulacağı ekrandır. Ana ekrandan UX Generator butonundan açılır.

![](RackMultipart20221123-1-ssx3ak_html_cf99d06a1a24c239.png)

## Header Create

**Header Create** : Sayfanın xml tarafında header kısmı generate edilir.

## Content

![](RackMultipart20221123-1-ssx3ak_html_709d8ac596f8c0d1.png)

Sayfanın içerik kısmının generate edildiği ekrandır.( TextBox, ComboBox vb).

Profile Id ve Object Id alanları doldurulduğunda seçilen objenin ObjectType değerine göre resultları veya tablo sütun isimleri gride doldurulur.

User Control, Next Page, Modal kısmı işlevsizdir.

Ctrl + z ile Context gridindeki bir satırı ComboBox olarak değiştirilebilir.

Ctrl + x ile Context gridindeki bir satırı User Control olarak değiştirilebilir. Kullanmayınız

View ekranındaki gridde Ctrl + x ve Ctrl + z seçili olar satırı yukarı aşşağı hareket ettirir.

**Content Create** : Xml kısmını generate eder.

**JavaScript Create** : JavaScript kısmını generate eder.

Sonuçları Result ekranına yazar.

**Up** : Context gridinde seçili satırı yukarı çıkartır.

**Down** : Context gridinde seçili satırı aşşağı indirir.

## Grid Create

![](RackMultipart20221123-1-ssx3ak_html_e893d5c22f3af79.png)

Sayfanın Grid xmlinin ve Get Servisinin generate edildiği ekrandır. Object Id olarak sayfada kullanacağınız get servisini seçiniz. Objectin Object Type alanı TABLE ise Crud type alanından get servisini veya tüm servisler aynı objectten geliyor ise Tümü seçeneğini seçiniz.

Profile Id ve Object Id alanları doldurulduğunda seçilen objenin ObjectType değerine göre resultları veya tablo sütun isimleri listelenir.

**Grid Create** : Gridin xml kısmı generate edilir.

**JavaSrcipt Create**** :** Gridin Get servisi generate edilir

## Grid Service

![](RackMultipart20221123-1-ssx3ak_html_8737285e39c3b278.png)

Gridin Update ve Create servislerinin oluşturulacağı ekrandır.

Grid Create ekranında seçilen Objectin Object Type I **Custom**** Sql** ise yukarıdaki gibi create ve update servisleri Grid Service ekranında görünür.

Object Type Table ise Grid Create ekranında Crud Type seçimine göre gizlenecek veya görünecektir.

## File Export

![](RackMultipart20221123-1-ssx3ak_html_164769a4846cb97d.png)

Sayfanın xml ve js dosyalarının oluşturulacağı ekrandır.

Sayfa ismi dosya ismidir.

Path Application Application Folder comboboxından seçilen flasöre göre değişir.

**Export** : Export JavaScript checkbox işaretli ise javasrcipt dosyasını oluşturur.

Export Xml checkbox işaretli ise xml dosyasını oluşturur.

Override Write File checkbox işaretli ise Page Name ile aynı isme sahip dosyanın üstüne generate eder.

İşaretli değilse PageName\_Copy olarak yeni dosya oluşturur. Aynı sayfa yeni checkbox işaretli olmadan export edilirse PageName\_Copy dosyasının üzerine yazar.

## Action, String, Page, Menu Option

![](RackMultipart20221123-1-ssx3ak_html_749f8142f0d0770.png)

Action Option tablosuna verilerin ekleneceği ekrandır.

File Export ekranından dosyalar generate edildiğinde Action,String Page, Menu Optionların hepsinin gridleri doldurulur. Diğer option ekranlarıda bu ekran gibi çalışmaktadır.

**Add Actions** : Griddeki verileri ACTİON\_OPTİONS tablosuna ekler.

**List Options** : Griddeki verilerin ACTİON\_OPTİONS tablosunda bulunursa Resul gridinde listelenir.

## One Service

![](RackMultipart20221123-1-ssx3ak_html_cf031fa24fe40cd1.png)

Yanlızca ComboBox servisi oluşturlan ekrandır.

Service JavaScript alanından Servis Metodları generate edilir.

Static Values JavaSrcipt alanından static metodlar generate edilir.

## Events

Events kısmı hiçbirşey ifade etmiyor.

## Application Configuration

Uygulamanın konfigrasyon ayarlarını yapılması gerekmektedir. Orneğin yeni bir ProfileId eklemek.

Bu ayarların yapıldığı dosyalar default olarak aşşağıdaki pathde bulunur.

C:\Program Files (x86)\Generator\JsonFiles

## DirectoryPath.json File

Hangi UX ile çalışacaksanız bulunduğu Pathi girmeniz gerekmektedir. Aksi takdirde Export ile dosya basılamaz. Default da bulunan pathler **FibaUx, Box Acquiring Ux ver BOS Clearing Ux**. Bu pathleri isterseniz silebilir ve ek olarak eklemek isterseniz aşşağıdaki formatta girmeniz gerekmektedir.

{

"Application": "BOS Clearing Ux",

"path": "G:\\Clearing\\clearing-ux-web\\UX.Web"

}

## ObjectProfile.json File

Hangi ProfileId ile çalışıyoranız burada ismini aşşağıdaki formatta girmeniz gerekmektedir.

"ISS\_PRM"

## Services.json File

Master veritabanında Profile Id ye karşılık gelen ORCLSRV19 veritabanındaki ..\_OPTİONS tablolarında kullanılan Service Id aşşağıdaki formatta girilmektedir.

{

"ProfileId": "ISS\_PRM",

"ServiceId": "PRMBackoffice"

},

## StaticMethods.json File

Statik metodların bulunduğu dosyadır. Genel olarak kullanılan metodlar bulunmaktadır. Yeni method eklemek isterseniz aşşağıdaki formatta ekleyebilirsiniz.

{

"MethodName": "OneToTwelve",

"MethodDescription": "1-12 between number",

"KeyType": "int",

"KeyName": "Number",

"Number": [

1,

2,

3,

4,

5,

6,

7,

8,

9,

10,

11,

12

]

},

**MetodName** : UX Generatorda method listesinde görünecek isimdir. Özellikle **List** ile sonlandırmayınız. Generator .js dosyasını oluştururken MethodName+List olarak çalışmaktadır.

**MethodDescription :** Method tanımıdırı. Herhangi bir etkisi yoktur. Boş değer alsa girmeniz gerekmektedir.

**KeyName :** Anahtar olarak kullanılacak objenin ismidir. Örneğin [{Number:1},{Number:2}]

**KeyType** : Anahtarın veri türüdür. int, string, String olarak girebilirsiniz.

**Number** : KeyName ile aynı isimde object oluşturup değerlerini girmeniz gerekmektedir.

**Sonuç** :

[{Number: 1},{Number: 2},{Number: 3},{Number: 4},{Number: 5},{Number: 6},{Number: 7},{Number: 8},{Number: 9},{Number: 10},{Number: 11},{Number: 12}

İstenilirse Key Value olarak da girilebilir. Aşşağıdaki örnekte anlatılmıştır.

{

"MethodName": "BlockPeriodType",

"MethodDescription": "DailyMonthly,Weekly",

"KeyType": "string",

"KeyName": "BlockPeriod",

"BlockPeriod": [

"D",

"M",

"W"

],

"ValueType": "String",

"ValueName": "BlockPeriodType",

"BlockPeriodType": [

"DAILY",

"MONTHLY",

"WEEKLY"

]

},

**ValueName :** Değer olarak kullanılacak objenin ismidir. Örneğin [{BlockPeriodType:"DAILY"}}

**ValueType** : Değer veri türüdür. int, string, String olarak girebilirsiniz.

**Sonuç :**

{ BlockPeriod: "D", BlockPeriodType: "DAILY" },

{ BlockPeriod: "M", BlockPeriodType: "MONTHLY" },

{ BlockPeriod: "W", BlockPeriodType: "WEEKLY" }

## SchemaNames.json File

Şemaların eklendiği dosyadır. Aşşağıdaki formatta yeni şema ekleyebilirsiniz.

"MRC",
