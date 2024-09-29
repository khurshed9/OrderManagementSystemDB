```README для API Системы Управления Заказами
Описание проекта
Этот проект представляет собой RESTful API для системы управления заказами, разработанный с использованием технологий .NET 8, Dapper, и PostgreSQL. API предоставляет возможность управлять клиентами, продуктами и заказами, а также выполнять аналитические запросы для получения статистики.

Технологии
.NET 8 (ASP.NET Core Web API): Фреймворк для создания веб-приложений и API.
Dapper: Микро ORM для работы с базой данных PostgreSQL.
PostgreSQL: Система управления базами данных для хранения данных.
Асинхронное программирование: Улучшение производительности и отзывчивости API.
Dependency Injection (DI): Упрощает управление зависимостями и тестирование.
Class Library: Структурирование проекта на модули для улучшения поддержки.
Структура базы данных
Проект использует четыре основные таблицы:

Customers (Клиенты)

Id: UUID, Primary Key
FullName: уникальная строка
Email: уникальная строка
Phone: строка
CreatedAt: дата создания
Products (Продукты)

Id: UUID, Primary Key
Name: уникальная строка
Price: число
StockQuantity: количество на складе
CreatedAt: дата создания
Orders (Заказы)

Id: UUID, Primary Key
CustomerId: UUID, Foreign Key
TotalAmount: число
OrderDate: дата заказа
Status: строка (например, "Pending", "Completed")
CreatedAt: дата создания
OrderItems (Элементы заказа)

Id: UUID, Primary Key
OrderId: UUID, Foreign Key
ProductId: UUID, Foreign Key
Quantity: число
Price: число
CreatedAt: дата создания
Функциональность API
API поддерживает следующие функции:

CRUD-операции
Создание, чтение, обновление и удаление клиентов, продуктов и заказов.
Эндпоинты
Получение клиентов с заказами за определённый период

GET /api/customers/orders?startDate={startDate}&endDate={endDate}
Получение продуктов с нулевым количеством на складе

GET /api/products/out-of-stock
Получение статистики по клиентам

GET /api/customers/statistics
Получение всех заказов с информацией о клиентах и товарах

GET /api/orders/details
Фильтрация заказов по статусу и дате

GET /api/orders?status={status}&startDate={startDate}&endDate={endDate}
Получение самого популярного продукта

GET /api/products/popular
Получение статистики по продажам за месяц

GET /api/orders/sales-statistics?month={month}&year={year}
Получение клиентов, не делавших заказы в течение последнего года

GET /api/customers/inactive
Получение всех заказов для конкретного продукта

GET /api/products/{productId}/orders
Получение информации о заказах с общей суммой по продуктам

GET /api/orders/products-summary

Заключение
Данный проект предоставляет мощное API для управления заказами, клиентами и продуктами, а также позволяет получать аналитические данные для улучшения бизнеса. Проект легко расширяем и поддерживаем благодаря модульной структуре и использованию современных технологий.
```