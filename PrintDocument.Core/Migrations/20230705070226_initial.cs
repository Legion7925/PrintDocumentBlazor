﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintDocument.Core.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAndFamily = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlainText = table.Column<string>(type: "ntext", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "بدون موضوع", null },
                    { 2, "تاریخی", null },
                    { 3, "معارف", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "NameAndFamily", "PasswordHash", "PhoneNumber", "Username" },
                values: new object[] { 1, "root", "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=", "", "root" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 4, "سخنرانی", 3 });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CategoryId", "PlainText", "Title" },
                values: new object[,]
                {
                    { 1, 2, "در سال‌های اولیه قرون وسطی، زمانی که امپراتوری روم به پایان می‌رسید و اروپا در حال تغییرات عمده‌ای بود، دوران باستان را نشان می‌دهد. در این دوران، فرهنگ‌های مختلف در سراسر جهان شکل گرفتند و تمدن‌های جدید در آسیا، اروپا، آفریقا و آمریکا ظهور کرد.\r\n\r\nیکی از رویدادهای مهم در تاریخ دوران باستان، پیدایش و گسترش امپراتوری روم بود. در اوج قدرت خود، امپراتوری روم بیش از ۲۵۰۰ سال به وجود بود و بخشی از آن در قاره‌های اروپا، آفریقا و آسیا را شامل می‌شد. امپراتوری روم در طول تاریخ خود به یکی از بزرگترین و تأثیرگذارترین امپراتوری‌های جهان تبدیل شد و فرهنگ رومی، هنر، علم و حقوق را ترویج کرد.\r\n\r\nدر طول قرن‌های ۴ تا ۶ میلادی، امپراتوری روم با نبرد با نیروهای بیرونی مانند قوم‌های غربی، هون‌ها و ویزیگوت‌ها مواجه شد. در این دوران، پادشاهان قوم‌های بربری نیز به تدریج در شمال آفریقا و حومه امپراتوری روم قدرت گرفتند.\r\n\r\nاما در قرن ۵ میلادی، زمان سقوط امپراتوری روم فرا رسید. ضعف داخلی، تهاجم‌های بیرونی و تغییرات اجتماعی باعث فروپاشی امپراتوری شد. در نتیجه، امپراتوری روم به دو بخش شرقی و غربی تقسیم شد. بخش غربی در نهایت با تهاجم سرخانه‌ها در سال ۴۷۶ میلادی نابود شد، در حالی که بخش شرقی تحت تأثیر قوی ترکان و امپراتوری‌های اسلامی قرار گرفت.\r\n\r\nبنابراین، دوره باستان را می‌توان به عنوان زمانی از تغییرات فرهنگی، سیاسی و اجتماعی در جهان نگریست که بر تاریخ بشر تأثیرات عمده‌ای گذاشت.", "قرون وسطی" },
                    { 3, 1, "سلام و عرض ادب به تمامی حضار محترم. من امروز در این مجمع با شما هستم تا درباره یک موضوع مهم صحبت کنم. موضوعی که بر جامعه‌ی ما و تمامی افراد حاضر تأثیرگذار است و نیازمند توجه و همکاری همه‌ی ماست.\r\n\r\nامروزه، جهان ما درگیر چالش‌های زیادی است. مسائلی از جمله تغییرات آب و هوا، کاهش تنوع زیستی، فقر، تروریسم و تضادات اجتماعی بر جامعه‌ها و کشورها تأثیر می‌گذارند. این چالش‌ها نه تنها برای حال حاضر بلکه برای آینده‌ی نسل‌های آینده نیز خطرناک هستند.\r\n\r\nاما من امیدوارم. امیدوارم که با همکاری و همبستگی، ما می‌توانیم این چالش‌ها را پیش روی خود متوقف کنیم و به سوی یک جامعه بهتر حرکت کنیم. برای دستیابی به این هدف، ما باید تغییرات را از خود آغاز کنیم.\r\n\r\nتغییرات باید از درون شروع شود. هر فرد در جامعه ما می‌تواند با اقدامات کوچکی تأثیر بزرگی را در زندگی خود و دیگران داشته باشد. ما باید به دنبال استفاده بهینه از منابع طبیعی باشیم، محیط زیست را حفظ کنیم و به توسعه پایدار تمایل نشان دهیم.\r\n\r\nعلاوه بر این، باید به همدلی و همبستگی با دیگران توجه کنیم. ما باید به یکدیگر کمک کنیم و به همدیگر حمایت کنیم. همه ما در یک قایق هستیم و تنها با هم می‌توانیم به ساحل أمان برسیم.\r\n\r\nدوستان عزیز، همین الان زمانی است که باید اقدام کنیم. اقدامات کوچک و نیروهای متحد ما را قادر خواهد ساخت تا در برابر چالش‌های دشوار شکست ناپذیر باشیم.\r\n\r\nبا همکاری، همبستگی و تصمیم به تغییر، ما می‌توانیم آینده‌ای روشن تر و بهتر را بسازیم. بگذارید امید و همت ما به عنوان جامعه یک نور پراکنده در تاریکی باشد و به همه‌ی افراد امید و شجاعت بدهد.\r\n\r\nبا تشکر از حضور شما و امیدوارم که با همدلی", "سخنرانی من" },
                    { 2, 4, "بسم الله الرّحمن الرّحیم\r\n\r\nو الحمد لله ربّ العالمین و الصّلاة و السّلام علی سیّدنا محمّد و آله الطّاهرین سیّما بقیّة الله فی الارضین.\r\n\r\nخیلی خوش آمدید برادران عزیز، خواهران عزیز، کارکنان محترم قوّه‌ی بسیار حسّاس قضائی که حقیقتاً زحمت در این مجموعه‌ی دادگستری کشور به‌ خاطر اهمّیّت زیادی که این قوّه دارد، دارای اجر مضاعف است؛ ان‌شاءالله که موفّق و مؤیّد باشید.\r\n\r\nاوّلاً اشاره کنم به اهمّیّت این روزها؛ شماها که خدمتگزاران نظام اسلامی هستید و ان‌شاءالله پیش خدای متعال ارج و قرب دارید، در این ایّام، بخصوص این یکی دو روز آخر دهه‌ی باعظمت اوّل ذی‌حجّه، ارتباط قلبی‌تان با خدای متعال را هر چه میتوانید تقویت کنید. روز عرفه را که فردا است، قدر بدانید و با دعا و تضرّع و توجّه و مسئلت از خداوند متعال به معنای واقعی کلمه گره‌گشایی کنید. اگر فضل الهی و لطف الهی نباشد، کوشش‌های ما، و زحماتی که میکشید و میکشیم، به جایی نمیرسد. در دعای شریف کمیل [عرض میکند:] «لا یُنالُ‌ ذلِکَ‌ اِلّا بِفَضلِک‌»؛(۲) یعنی همه‌ی وظایف را انجام میدهیم، [امّا] آنچه به این تلاشهای ما و وظایف ما روح میدهد، جان میدهد، لطف الهی و فضل الهی و توجّه الهی است. البتّه در همه‌ی آنات میشود با خدا ارتباط گرفت؛ رابطه گرفتن با خدا آسان است منتها بعضی از ساعات، بعضی از روزها یک اهمّیّت ویژه‌ای دارد؛ در رأس این روزها، یکی همین فردا [یعنی] روز عرفه است؛ عید قربان هم همین‌جور.\r\n\r\nیادی کنیم از شهید بهشتی (رضوان الله علیه) که تعیین این روز به مناسبت یادبود آن شهید بزرگوار است. مرحوم بهشتی (رضوان الله تعالی علیه) علاوه بر مقامات علمی که معقولاً و منقولاً دارای رتبه‌ی عالی علمی بود ــ ایشان هم در علوم معقول حوزوی، و هم در علوم منقول حوزوی حقّاً و انصافاً رتبه‌ی بالایی داشت ــ و ملّای حسابی‌ای بود، علاوه‌ی بر اینها خصوصیّات اخلاقی و کاری این بزرگوار میتواند برای همه‌ی ما درس باشد. اوّلاً بسیار پُرکار بود؛ از کار اظهار خستگی نمیکرد و همان قدری که توان داشت، واقعاً همه را صرف کار میکرد. بسیار بانظم بود که در طول سالهای متمادیِ آشنایی و همکاری با ایشان، چه قبل از انقلاب، چه بعد از انقلاب، من هیچ کس را در بین دوستان خودمان، مرتبطین خودمان، مثل مرحوم آقای بهشتی در نظم ندیدم؛ نظم کار. نظم خیلی مهم است. باابتکار بود، پُرحوصله بود؛ در مقابل اعتراض حتّی اعتراضهای اهانت‌آمیز از جا درنمیرفت؛ حرفها را می‌شنید، حتّی حرف مخالف را می‌نشست گوش میداد و می‌شنید؛ بسیار پُرحوصله [بود]. اینها همه برای ما درس است، باید یاد بگیریم این‌جوری عمل کنیم. بی‌تظاهر بود؛ آدم اهل تظاهری نبود؛ نه، ما سالهای طولانی دیده بودیم؛ باطن او همان چیزی بود که در ظاهرش آن را نشان میداد. آدم اهل تظاهر نبود. خب خدای متعال هم اجرِ شایسته‌ی برترین بندگان خودش را به او داد و آن، شهادت به دست اشقی‌الاشقیاء در آن دوران بود که خدای متعال آن را به این بنده‌ی مؤمن و صالح خودش هدیه کرد.\r\n\r\nدرباره‌ی قوّه‌ی قضائیّه خب حرفهای زیادی هست؛ هم در تذکّر، هم در باب تشکّر؛ هم میشود تشکّر کرد، هم میشود تذکّر داد؛ حرف زیاد است. مطالبی که جناب آقای محسنی اینجا بیان کردند، مطالب مهمّی بود؛ این [مطالبی] که ایشان گفتند، بنده هم طیّ گزارشات مختلف خیلی از همین چیزها را شنیده‌ام و اطّلاع دارم. مطالب مهمّی را ایشان بیان کردند. خب یکی از محسّنات جناب آقای محسنی آشنایی با زوایای قوّه‌ی قضائیّه است؛ سالها ایشان در این قوّه بوده‌اند و حضور داشته‌اند. بنده هم چند جمله‌ای را در این موارد عرض میکنم.\r\n\r\nاوّلاً اهمّیّت قوّه‌ی قضائیّه است. شماها که یا به صورت قاضی ــ چه قاضی دادگاه، چه قاضی دادسرا ــ یا به صورت کارمند مثلاً، به هر شکلی، در این قوّه مشغول خدمت هستید، بدانید در یکی از مهم‌ترین ارکان نظام اسلامی دارید کار میکنید و با خیلی جاهای دیگر قابل مقایسه نیست. واقعاً قوّه‌ی قضائیّه یکی از ستونهای اصلی در برپایی نظام اسلامی است. معلوم است که اگر در این ستونهای اصلی اختلالی به وجود بیاید، در کلّ نظام اختلال به وجود خواهد آمد. بنابراین کارتان بسیار مهم است. به همین نسبت، اگر چنانچه اشتباهاتی در اینجا انجام بگیرد، اختلالی صورت بگیرید، ضربه‌ی آن هم مهم است؛ این [طور] است دیگر؛ وقتی جایگاه انسان بالا رفت، هم کار مثبت او، هم کار منفی او، هر دو، تأثیراتش تأثیرات شگرفی است. شما این‌جوری هستید؛ کار خوبتان هم، کار مثبتتان هم، تأثیر شگرفی دارد در بهبود زندگی مردم، در پیشرفت نظام اسلامی؛ خدای‌ نکرده اشتباهی هم بکنید، همین‌جور است.\r\n\r\nبنده در سال گذشته، در این دیدار سالیانه‌ای که با شما داریم، موارد مهمّی را عرض کردم،(۳) نمیخواهم باز همانها را تکرار کنم یا بتفصیل صحبت کنم؛ یک چند نکته را فقط تأ‌کید میکنم. کارهایی که ما سال گذشته گفتیم، خب من همان وقت اطّلاع پیدا کردم که در قوّه‌ی قضائیّه یک قرارگاهی تشکیل شد برای پیگیری آن کارها. در بخشی از آن کارها پیشرفتهای خوبی هم بوده، در بخشی هم پیشرفتی نبوده؛ بالاخره کار شد، ترتیباتی فراهم شد، که خود این ایجاد ترتیبات برای اینکه کارها را جلو ببرند، یک چیز مهم و قابل توجّهی است؛ منتها یک نکته را من عرض بکنم: مناط(۴) داوری خودتان را کاری که انجام داده‌اید قرار ندهید؛ مناط داوری را خروجی کار قرار بدهید. مثلاً‌ فرض کنید اینکه ما سر فلان قضیّه این کارها را کردیم، این تعداد جلسه گذاشتیم و غیره، اینها ملاک نیست؛ ملاک این است که نتیجه چه شد، خروجی کارها چه شد؛ در همه‌ی مسائل کشور این‌جوری است. آمارها مهمّند منتها باید نشان داده شود که خروجی این آمارها و این مطالبی که گفته شد چیست؛ آن مهم است. محصول نهایی مهم است که دست مردم چه میرسد.\r\n\r\nاوّلین مطلبی که من میخواهم عرض کنم، همین مسئله‌ی تحوّل در قوّه‌ی قضائیّه است. خب قوّه‌ی قضائیّه چهل و چند سال پشتوانه‌ی تجربه و آزمون و خطا دارد؛ این خیلی مهم است. چهل و چند سال است که ما در قوّه‌ی قضائیّه شاهد طرحهای گوناگون، برنامه‌های مختلف، اقدامهای گوناگون هستیم و این تجربه‌های متراکم و انباشته‌ای را در اختیار صاحب‌نظران قرار میدهد؛ این چیز خیلی باارزشی است؛ از این تجربه‌ها باید استفاده کرد برای تحوّل. تحوّل را هم معنا کردیم؛ تحوّل یعنی نقاط مثبت را تقویت کنیم، نقاط منفی را به صفر برسانیم؛ این معنای تحوّل است. گاهی اوقات به صفر رساندن نقاط منفی مستلزم یک کار مهمّ تغییر سازمانی است؛ در سازمان باید تغییر داده بشود؛ گاهی در جهت‌گیری‌ها باید تغییر داده بشود؛ موارد معدودی در آدمها باید تغییر داده بشود؛ تحوّل به این چیزها احتیاج دارد؛ این تحوّل است.\r\n\r\nطرح تحوّلی چند سال قبل از این در قوّه‌ی قضائیّه تهیّه شده. کارشناس‌هایی که در این چند سال راجع به این طرح با بنده صحبت کردند یا گزارش کتبی دادند، همه میگویند این طرح، طرحِ خوبی است، طرح متقنی است. این طرح الان در اختیار شما است، در اختیار قوّه‌ی قضائیّه است. من سال گذشته هم روی آن تکیه کردم. این طرح باید پیش برود، باید پیشرفت کند؛ پیشرفتش کم بوده. باید به سمت عملی شدن، عملیّاتی شدن طرح تحوّل و سند تحوّل قوّه‌ی قضائیّه پیش بروید. البتّه احتیاج دارد به بودجه، که دولت و مجلس باید کمک کنند؛ احتیاج دارد به نیروهای کارآمد، که در بعضی از جاها نیروهای کارآمد بحمدالله هستند، در بعضی از جاها هم شاید بایستی یک مقداری بحث نیروی کارآمد و قوی تقویت بشود. احتمالاً یک مواردی [از سند] هم باید تغییر پیدا کند؛ بالاخره هر سند که دائمی و ابدی نیست.\r\n\r\nشاید مواردی باید به‌روزرسانی بشود؛ این هم یک نکته‌ی دیگر است. سند را نگاه کنید، ببینید کجا به تکمیل احتیاج دارد، کجا به به‌روزرسانی احتیاج دارد، آن را روزآمد کنید؛ لکن باید عمل بشود. حُسن این سند و هر سندِ برنامه‌ای در این است که کار را منضبط میکند؛ از پراکنده‌کاری جلوگیری میکند، کار منضبط پیش میرود؛ این خیلی چیز مغتنم و مهمّی است. البتّه به قانون هم احتیاج دارد. یک مواردی اِعمالِ سند احتیاج به قانون دارد، که این را هم باید مجلس کمک کند؛ شما باید بخواهید، از دولت و مجلس مطالبه کنید تا قانون را برایتان فراهم بکنند.\r\n\r\nمن به مناسبت اینکه گفتم [تحوّل قوّه‌ی قضائیّه] احتیاج به نیروی کارآمد دارد، همین جا از فرصت استفاده کنم و تأکید کنم بر روی ساختن نیروهای متخصّص، پرورش نیروهای متخصّص؛ این از جمله‌ی کارهای خیلی لازم است. قوّه‌ی قضائیّه بایستی در هر بخشی از بخشها یک مجموعه‌ی آماده‌ی متخصّص و کارشناس در اختیار داشته باشد که هر وقت لازم شد ــ تبدیلی، تغییری، اضافه‌کردنی [بود] ــ از اینها استفاده کند. این مسئله‌ی جانشین‌پروری که بنده در مورد دستگاه‌های مختلف گفته‌ام، اینجا مصداقش همین پرورش نیروهای متخصّصی است که عرض کردم. این یک مطلب که من روی این تأکید میکنم، تکیه میکنم. مسئله‌ی سند را با همین خصوصیّاتی که عرض شد، جدّی بگیرید.\r\n\r\nمسئله‌ی بعدی مسئله‌ی مبارزه با فساد است، هم در درون قوّه، هم در بیرون قوّه؛ یکی از وظایف شما این است. البتّه [مبارزه با فساد در] درون قوّه را به جناب آقای محسنی هم که دیروز پریروز با ایشان ملاقات داشتیم گفتم و روی این تکیه کردم. البتّه یک اکثریّت قاطع ــ نزدیک به همه ــ در قوّه‌ی قضائیّه مردمان شریفی‌اند، چه قضات، چه کارمندان؛ با امکانات کم، با درآمد کم ــ واقعاً کم ــ دارند کار سخت انجام میدهند. شرافت این عزیزان را انسان نبایست از نظر دور بدارد. یک اقلّیّت کوچکی هم هستند که از موقعیّت سوء استفاده میکنند و چهره‌ی قوّه را در نظر مردم مخدوش میکنند. این کسی هم که این کار را انجام میدهد، یعنی کار خلاف را انجام میدهد، لزوماً قاضی نیست؛ گاهی مثلاً منشی فلان دادسرای فلان شهر دوردست یک حرکتی انجام میدهد، همین را تکثیر میکنند و غلبه میدهند به قوّه و بر اساس آن روی قوّه قضاوت میکنند. حیف است [چنین شود]. با این باید مبارزه کرد. باید همه‌ی اجزای قوّه مراقبت کنند که فساد وارد نشود. فساد چیز مسری‌ای هم هست. خدای نکرده وقتی [در] یک بخشی فساد وارد شد، این بیماری سرایت میکند؛ روزبه‌روز هم زیادتر میشود. وقتی که با فاسد برخورد نشود، فساد افزایش پیدا میکند. این در درون قوّه ، در بیرون قوّه هم همین جور.\r\n\r\nحالا البتّه در بیرون قوّه دیگران هم در مسئولیّتِ جلوگیری از فساد شریکند؛ یعنی گاهی یک فسادی واقع میشود، منشأ فساد دست قوّه‌ی قضائیّه نیست، دست قوّه‌ی مجریّه است، دست قوّه‌ی مقنّنه است، دست نیروهای مسلّح است؛ آنها بایستی جلوی مبادی و مناشئ فساد را بگیرند. البتّه اگر چنانچه قطع نشد، جلویش گرفته نشد، آن‌وقت وظیفه‌ی قوّه‌ی قضائیّه است که وارد بشود. البتّه امروز آدمهای مغرض و مریض‌القلب، آنهایی که واقعاً «فی قُلوبِهِم مَرَض»(۵) هستند، شایعه‌پراکنی‌ای که علیه قوّه‌ی قضائیّه میکنند، گاهی جنجال میکنند، گاهی یک چیزی میگویند، خیلی بیشتر از واقعیّت آن چیزی است که در قوّه وجود دارد لکن نگذارید؛ همین را دنبال کنید. این هم نکته‌ی دوّمی که راجع به مسئله‌ی فساد عرض کردیم.\r\n\r\nیک مسئله‌ی دیگر که اینجا من یادداشت کرده‌ام و جزو مناشئ فساد است و گفتیم دست قوّه‌های دیگر است، همین نکته‌ای بود که آقای محسنی هم به آن اشاره کردند، [یعنی] همین مسئله‌ی سلب اعتبار از معاملات غیر رسمی در اموال غیرمنقول؛ این چیز مهمی است. خیلی از فسادها در مورد اموال غیرمنقول، از همین معاملات غیر رسمی و معاملات عادی به وجود می‌آید؛ باید جلوی این گرفته بشود. و واقعاً این‌جوری است که اگر حالا به فرض از دیدگاه شورای محترم نگهبان یک اشکالی هم این قانون مجلس داشته باشد، مصلحت قطعی نظام و کشور در این است که این قانون دنبال بشود؛ یعنی این شیوه‌ای که الان رایج است که دو خط بنویسند، منتقل کنند و مانند اینها، خودش منشأ فسادهای بزرگ است. این هم این مطلب.\r\n\r\nمطلب بعدی درباره‌ی وظایف دیگر قوّه‌ی قضائیّه است. به قانون اساسی که شما مراجعه میکنید، می‌بینید که وظیفه‌ی قوّه‌ی قضائیّه فقط محکمه‌داری در دادسراها یا در دادگاه‌ها نیست که دادرسی دعاوی و اختلافات و مانند این چیزها باشد؛ فقط این نیست؛ وظایف مهمّ دیگری در قانون اساسی بر عهده‌ی قوّه‌ی قضائیّه گذاشته شده. مثلاً یکی از آنها احیای حقوق عامّه است؛ حقوق عامّه خیلی چیز مهمّی است. شناسایی حقوق عامّه خودش یک مسئله است؛ احقاقش [هم] یک مسئله‌ای است که خیلی هم سخت است. حالا مثلاً اگر من بخواهم مثال بزنم، یکی از حقوق عامّه، امنیّت روانی جامعه است. اینکه یک عدّه‌ای آنجا بنشینند و با استفاده از فضای مجازی یا غیرمجازی مدام روی اعصاب مردم راه بروند و امنیّت ذهنی مردم را به هم بزنند، مردم را بترسانند و مانند اینها، خب این خلاف مقتضای احیای حقوق عامّه است و قوّه‌ی قضائیّه باید وارد بشود. البتّه اطّلاع دارم که در بعضی اوقات و در بعضی از موارد دادستانی‌ها وارد شده‌اند و کارهایی هم انجام داده‌اند، لکن باید با برنامه‌ریزی و با انضباط این کار انجام بگیرد، این کار باید با قاعده انجام بگیرد؛ این جایش خالی است و بایستی مثلاً این کارها را انجام بدهد.\r\n\r\nیا «تأمین آزادی‌های مشروع»؛ یکی از وظایف قوّه‌ی قضائیّه تأمین آزادی‌های مشروع است. خیلی دقیق نوشته‌اند؛ آزادی مطلق نیست، آزادی مشروع. آزادی مشروع همان است که شرع اجازه میدهد. قانون اساسی این است. در ذیل حکم شرع، آزادی‌های مردم باید تأمین بشود. خب، دستگاه‌های قدرت به طور طبیعی در یک مواردی دچار معارضه میشوند؛ چه کسی باید در این زمینه به داد مردم برسد؟ قوّه‌ی قضائیّه؛ یعنی یکی از کارهای مهمّ قوّه‌ی قضائیّه همین است. یا مثلاً پیشگیری از وقوع جرم که البتّه این از جمله‌ی آن مواردی است که دستگاه‌های دیگر هم در آن نقش دارند؛ اینها چیزهایی است که در قانون اساسی به اینها تصریح شده و بایستی برای اینها برنامه‌ریزی کرد. اینها چیزهایی نیست که با حرف زدن و با گفتن و تصمیم‌گیری‌های موردی و موضعی و فردی و ریاستی و مانند اینها حل بشود؛ اینها برنامه‌‌ریزی میخواهد، دستور میخواهد، روش میخواهد، احیاناً قانون میخواهد؛ باید اینها دنبال بشود. و این کارها ساز و کارِ سنجیده و اندیشیده لازم دارد؛ باید نشست، فکر کرد، اندیشید. خب حالا اینها ظرفیّتهای قانونی قوّه‌ی قضائیّه است که باید از این ظرفیّتها حدّاکثر استفاده بشود.\r\n\r\nیک نکته‌ی دیگر هم مسئله‌ی برخورد با مراجعان است که این را هم ما قبلها گفته‌ایم(۶) و یک جاهایی هم البتّه انجام گرفته؛ این خیلی تأثیر دارد؛ یعنی کسی که مراجعه میکند به دادگستری، اگر چنانچه با اخم آن کسی که به او مراجعه شده مواجه بشود، این دل‌شکسته از آنجا بیرون می‌آید، ولو حالا شما آن اخم را بکنید بعد هم به کارش رسیدگی کنید، این باز همان تأثیر سوء را دارد و فرق نمیکند؛ یعنی برخوردِ خوب [لازم است]. البتّه کار سختی است، بنده میدانم؛ یعنی مراجعات مردمی گاهی اوقات واقعاً انسان را خسته میکند؛ در نوع مواجهه و مراجعه، آدم خسته میشود، اعصاب انسان [به هم میریزد] لکن باید تحمّل کرد.\r\n\r\nو آخرین مطلبی که میخواهم عرض کنم تصویر رسانه‌ای قوّه‌ی قضائیّه است. قوّه‌ی قضائیّه تصویر رسانه‌ای خوبی ندارد؛ از رسانه و تبلیغات بدرستی در این قوّه و برای این قوّه استفاده نمیشود. البتّه بخشی‌اش مربوط به دستگاه‌های رسانه‌ها [مثل] رادیو و تلویزیون و روزنامه‌ها و مانند اینها است، بخشی‌اش هم مربوط به خود درون قوّه است. خدا رحمت کند مرحوم آقای موسوی اردبیلی(۷) را؛ آن وقتها شکایت میکرد پیش ما از صداوسیما؛ میگفت که «اخبار قوّه‌ی قضائیّه بعد از اخبار کیفیّت راه جیرفت که [مثلاً] راه بسته است یا برف آمده و مانند اینها! اینها را که گفت، بعد نوبت میرسد به قوّه‌ی قضائیّه»؛ شکایت ایشان این بود. البتّه حالا این‌جور نیست؛ حالا بحمدالله از این جهت بهتر است لکن تصویر قوّه‌ی قضائیّه، این‌‌همه کاری که انجام گرفته، اینها را [باید] مردم بدانند،‌ اینها را مردم مطّلع بشوند. حالا همین نکته‌ای که آقای محسنی اشاره کردند، این نشست و برخاست با قشرهای مختلف، این خیلی مهم است؛ هم از لحاظ شکلی کار مهمّی است، کار بزرگی است، هم از لحاظ نتیجه‌گیری کار مهمّی است؛ خب قوّه‌ی قضائیّه گسترش پیدا میکند، فکرش باز میشود، افقها در مقابلش روشن میشود. با حقوق‌دان‌ها بنشینید، با افراد مختلف، کارشناس اقتصادی، کارشناس سیاسی، دانشجو، جوانهایی که ادّعا دارند، حرف دارند، استاد، کسبه، روحانیّون؛ این نشست و برخاست با اینها خیلی مهم است؛ خب اینها منعکس بشود؛ به شکل درست، منعکس بشود؛ یعنی گزارشگریِ درست انجام بگیرد.", "بیانات مقام معظم رهبری در دیدار با مسئولان قوه قضاییه" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CategoryId",
                table: "Documents",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
