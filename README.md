# NewStackDojo

>## `Microsoft SQL Server`
> คือ service SQL server ของ Microsoft ที่เอาไว้จัดการเกี่ยวกับ database
> ### ข้อจำกัด
> - สร้าง database ได้มากสุดคือ 32,767
> ### ข้อกำหนดเบื้องต้น
> - Create database statement มันจะ autocommit เป็น default และจะไม่อนุญาติ explicit หรือ implicit transaction
>  ### คำแนะนำ
> - master database จะถูก back up ไว้เมื่อไรก็ตามที่มีการสร้าง,เปลี่ยนแปลง,ลบ
> - รองรับข้อมูลจำนวนมาก
> 
> มี 4 แบบ
> 1. enterprise  
> 2. standard
> 3. express
> 4. developer
>
> `Note : ` 
> - enterprise, standard สำหรับ production,มีค่าใช้จ่าย license, มี feature ให้ใช้เยอะ มีค่าใช้จ่ายสูง
> - express, developer เป็นแบบ free
> - express มีพื้นที่จัดเก็บจำกัด 10 GB (เพียงพอต่อการใช้งานกับ data ขนาดเล็ก)
> - developer มี feature ทุกอย่างเหมือน enterprise แต่ไม่สามารถใช้กับ production ได้
>


>## ADO.NET Entity Framwork
>
>

>## Feature Transaction