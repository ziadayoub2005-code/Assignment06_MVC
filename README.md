# 🎓 Assignment 06 — ASP.NET Core MVC & Advanced C#
### Course CRUD with Validation, No-Conditions View, Middleware Pipeline & Advanced C# Concepts

---

## 📌 معلومات الطالب والتكليف (Student & Assignment Info)
* **اسم الطالب (Student Name):** زياد محمد إمام محمود (Zeyad Mohamed Emam Mahmoud)
* **المحاضر (Instructor):** المهندس / عبدالرحمن شعبان الوكيل (Eng. Abdelrahman Shaaban Elwakeel)
* **المجموعة (Course Group):** DotNet With Elwakeel • DEPI
* **بيئة العمل (Tech Stack):** .NET 8.0, ASP.NET Core MVC, EF Core 8.0, C# 12, Bootstrap 5

---

## 📄 تقرير حل الأسئلة المقالية (Formatted PDF Report)
تم توثيق وحل جميع الأسئلة المقالية والبرمجية داخل ملف PDF منسق واحترافي من 7 صفحات:
* 📥 **رابط تحميل الملف:** [`Assignment_06_Solutions.pdf`](./Assignment_06_Solutions.pdf) أو من مجلد [`Assignment/Assignment_06_Solutions.pdf`](./Assignment/Assignment_06_Solutions.pdf).

---

## 🚀 محتويات التكليف والحل الهندسي (Assignment Tasks Overview)

### 1️⃣ مقال لينكد إن: رحلة الـ Request من Kestrel إلى Middleware Pipeline
* **خادم Kestrel:** خادم الويب الداخلي عالي الأداء الذي يستقبل الـ Raw TCP Packets ويحولها إلى كائن C# منظم `HttpContext`.
* **الـ Middleware Pipeline:** خط المعالجة التتابعي القائم على مبدأ الدمية الروسية (Russian Doll) ونمط Chain of Responsibility.
* **الـ Short-Circuiting:** إنهاء الرحلة مبكراً وإرجاع Response فوري (مثل التحقق من الصلاحيات Authentication).

---

### 2️⃣ تطبيق كامل لعمليات الـ CRUD لكائن Course مع Validation
تم تطبيق دورة الحياة الكاملة لكائن `Course` وفقاً لمبادئ MVC النظيفة:
* **الـ Model وقواعد التحقق ([Course.cs](./Demos/MVCGiza02Solution/MVCGiza02/Models/Course.cs)):**
  * `[Required]`, `[MinLength]`, `[MaxLength]`, `[Range]`, `[Display]`.
* **التحقق من جانب الخادم (Server-Side Validation):**
  * فحص `ModelState.IsValid` داخل الـ POST Actions (`SaveAdd` و `SaveEdit`) في [`CourseController.cs`](./Demos/MVCGiza02Solution/MVCGiza02/Controllers/CourseController.cs).
  * فحص منطقي مخصص: درجة النجاح يجب أن تكون أقل من الدرجة الكلية.
* **التحقق من جانب العميل (Client-Side Validation):**
  * تطبيق Tag Helpers مع سكربتات `_ValidationScriptsPartial` داخل [`Add.cshtml`](./Demos/MVCGiza02Solution/MVCGiza02/Views/Course/Add.cshtml) و [`Edit.cshtml`](./Demos/MVCGiza02Solution/MVCGiza02/Views/Course/Edit.cshtml) للتحقق الفوري في المتصفح دون Postback.

---

### 3️⃣ صفحة نتيجة الطالب في الكورس (شرط: No Conditions in View)
طلب التكليف نصاً:
> *"Need to design a view that shows the name of student, name of course, the degree of this student in this course colored with green if the student passed the course and red if failed. Action takes id of student and id of course. >> no conditions in view"*

* **الحل الهندسي النظيف:**
  * تم عزل منطق اتخاذ القرار وتحديد اللون الأخضر/الأحمر وحالة النجاح بالكامل داخل الـ **Controller Action**.
  * تم تمرير النتائج جاهزة داخل ViewModel مخصص: [`StudentCourseResultViewModel.cs`](./Demos/MVCGiza02Solution/MVCGiza02/ViewModels/StudentCourseResultViewModel.cs).
  * صفحة العرض [`Result.cshtml`](./Demos/MVCGiza02Solution/MVCGiza02/Views/Course/Result.cshtml) نظيفة 100% ولا تحتوي على أي شرط `@if`.

---

### 4️⃣ الأسئلة المقالية المتقدمة (C# Advanced & Core Concepts)
* **Three Use Cases for Asynchronous Programming:**
  1. استعلامات قواعد البيانات الثقيلة (EF Core DB Queries).
  2. استدعاءات الـ APIs الخارجية وبوابات الدفع (External HTTP Calls).
  3. قراءة وكتابة وتدفق الملفات الكبيرة (File I/O & Streaming).
* **Difference between Thread and Task:**
  * مقارنة تفصيلية بين مسار نظام التشغيل المنخفض (Thread) والتجريد العالي لمكتبة TPL المستند للـ ThreadPool (Task).
* **New Features in .NET 9 for Generic Types:**
  * دوال `CountBy` و `AggregateBy` في LINQ بدون GroupBy.
  * الدالة `Index<TSource>` للترقيم بدون استهلاك ذاكرة.
  * تحسينات مترجم RyuJIT في تخصيص الـ Generics (Generic Specialization & Devirtualization).
* **Built-in Delegates in Details:**
  * `Action` (من 0 إلى 16 معامل، يرجع `void`).
  * `Func` (من 0 إلى 16 معامل، والنوع الأخير هو الـ Return).
  * `Predicate` (معامل واحد فقط من النوع T، ويرجع دائماً `bool`).
* **Bonus Questions (من ملف 01.png):**
  * فوائد معمارية البرمجيات (Software Architecture).
  * معمارية الطبقات المتعددة (N-tier Architecture).
  * معمارية البصلة (Onion Architecture & Dependency Inversion).
  * سؤال المقابلات: *هل LINQ بطيء؟* والفرق بين الـ Deferred Execution والـ Eager Execution.

---

## 💻 طريقة تشغيل المشروع (How to Run)

1. فتح المشروع في **Visual Studio** أو **VS Code**:
   ```bash
   cd Demos/MVCGiza02Solution/MVCGiza02
   dotnet run
   ```
2. الروابط المباشرة داخل المتصفح:
   * قائمة الكورسات: `https://localhost:XXXX/Course/Index`
   * إضافة كورس جديد: `https://localhost:XXXX/Course/Add`
   * نتيجة طالب نموذجية (السؤال الثالث): `https://localhost:XXXX/Course/Result?studentId=1&courseId=1`
