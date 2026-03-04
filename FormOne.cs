using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SyncClientWinForms
{
   public partial class FormOne : Form
   {
      private const string BaseUrl = "http://127.0.0.1:8080/api/items";
      private static readonly WebClient Client = new WebClient();

      public FormOne()
      {
         InitializeComponent();
      }

      private void ButtonStart_Click(object sender, EventArgs e)
      {
         TextBoxReader.AppendText("Синхронный Json клиент");
         TextBoxReader.AppendText(Environment.NewLine);
         //TextBoxReader.ScrollToCaret();
         ListBoxReader.Items.Add("Синхронный Json клиент");
         //ListBoxReader.TopIndex = ListBoxReader.Items.Count - 1;
         RichTextBoxReader.AppendText("Синхронный Json клиент");
         RichTextBoxReader.AppendText(Environment.NewLine);
         //RichTextBoxReader.ScrollToCaret();

         // Устанавливаем Content-Type для JSON
         Client.Headers[HttpRequestHeader.ContentType] = "application/json";
         Client.Encoding = System.Text.Encoding.UTF8;
         try
         {
            // 1. Проверка доступности сервера
            TestServerConnection();

            // 2. Запрос всех элементов (должен быть пустой список)
            TextBoxReader.AppendText("\n2. Запрос всех элементов (должен быть пустой список):");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n2. Запрос всех элементов (должен быть пустой список):");
            RichTextBoxReader.AppendText("\n2. Запрос всех элементов (должен быть пустой список):");
            RichTextBoxReader.AppendText(Environment.NewLine);

            GetAllItems();

            // 3. Создание первого элемента
            TextBoxReader.AppendText("\n3. Создание первого элемента:");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n3. Создание первого элемента:");
            RichTextBoxReader.AppendText("\n3. Создание первого элемента:");
            RichTextBoxReader.AppendText(Environment.NewLine);

            Item item1 = CreateItem(new Item { Date = DateTimeOffset.UtcNow, Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), Id = 1, Vendor = "HP", Name = "Ноутбук", Price = 1567.89 });

            // 4. Создание второго и третьего элемента
            TextBoxReader.AppendText("\n4. Создание второго и третьего элемента:");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n4. Создание второго и третьего элемента:");
            RichTextBoxReader.AppendText("\n4. Создание второго и третьего элемента:");
            RichTextBoxReader.AppendText(Environment.NewLine);

            Item item2 = CreateItem(new Item { Date = DateTimeOffset.UtcNow, Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), Id = 2, Vendor = "ACER", Name = "Смартфон", Price = 234.56 });
            Item item3 = CreateItem(new Item { Date = DateTimeOffset.UtcNow, Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), Id = 3, Vendor = "DELL", Name = "Смартфон", Price = 543.21 });

            // 5. Запрос всех элементов (должно быть 3 элемента)
            TextBoxReader.AppendText("\n5. Запрос всех элементов (должно быть 3 элемента):");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n5. Запрос всех элементов (должно быть 3 элемента):");
            RichTextBoxReader.AppendText("\n5. Запрос всех элементов (должно быть 3 элемента):");
            RichTextBoxReader.AppendText(Environment.NewLine);

            GetAllItems();

            // 6. Получение элемента по ID
            TextBoxReader.AppendText("\n6. Получение элемента по ID :" + item2.Id);
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n6. Получение элемента по ID :" + item2.Id);
            RichTextBoxReader.AppendText("\n6. Получение элемента по ID :" + item2.Id);
            RichTextBoxReader.AppendText(Environment.NewLine);

            GetItemById(item2.Id);

            // 7. Обновление элемента с ID
            TextBoxReader.AppendText("\n7. Обновление элемента с ID :" + item1.Id);
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n7. Обновление элемента с ID :" + item1.Id);
            RichTextBoxReader.AppendText("\n7. Обновление элемента с ID :" + item1.Id);
            RichTextBoxReader.AppendText(Environment.NewLine);

            Item updatedItem = UpdateItem(item1.Id, new Item { Date = DateTimeOffset.UtcNow, Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), Id = 7, Vendor = "Lenovo", Name = "Игровой ноутбук", Price = 1678.95 });

            // 8. Проверка обновленного элемента
            TextBoxReader.AppendText("\n8. Проверка обновленного элемента:");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n8. Проверка обновленного элемента:");
            RichTextBoxReader.AppendText("\n8. Проверка обновленного элемента:");
            RichTextBoxReader.AppendText(Environment.NewLine);

            GetItemById(updatedItem.Id);

            // 9. Получение несуществующего элемента
            TextBoxReader.AppendText("\n9. Получение несуществующего элемента (ID=88):");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n9. Получение несуществующего элемента (ID=88):");
            RichTextBoxReader.AppendText("\n9. Получение несуществующего элемента (ID=88):");
            RichTextBoxReader.AppendText(Environment.NewLine);
            GetNonExistentItem(88);

            // 10. Удаление элемента
            TextBoxReader.AppendText("\n10. Удаление элемента с ID :" + item3.Id);
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n10. Удаление элемента с ID :" + item3.Id);
            RichTextBoxReader.AppendText("\n7. Обновление элемента с ID :" + item1.Id);
            RichTextBoxReader.AppendText(Environment.NewLine);
            DeleteItem(item3.Id);

            // 11. Проверка удаления элемента
            TextBoxReader.AppendText("\n11. Проверка удаления элемента:");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n11. Проверка удаления элемента:");
            RichTextBoxReader.AppendText("\n11. Проверка удаления элемента:");
            RichTextBoxReader.AppendText(Environment.NewLine);

            GetAllItems();

            // 12. Удаление несуществующего элемента
            TextBoxReader.AppendText("\n12. Удаление несуществующего элемента (ID=77):");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n12. Удаление несуществующего элемента (ID=77):");
            RichTextBoxReader.AppendText("\n12. Удаление несуществующего элемента (ID=77):");
            RichTextBoxReader.AppendText(Environment.NewLine);

            DeleteNonExistentItem(77);

            // 13. Тестирование некорректных данных
            TextBoxReader.AppendText("\n13. Тестирование некорректных данных:");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n13. Тестирование некорректных данных:");
            RichTextBoxReader.AppendText("\n13. Тестирование некорректных данных:");
            RichTextBoxReader.AppendText(Environment.NewLine);

            TestInvalidData();

            // 14. Тестирование неверного метода
            TextBoxReader.AppendText("\n14. Тестирование неверного метода (PATCH):");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\n14. Тестирование неверного метода (PATCH):");
            RichTextBoxReader.AppendText("\n14. Тестирование неверного метода (PATCH):");
            RichTextBoxReader.AppendText(Environment.NewLine);

            TestInvalidMethod();

            TextBoxReader.AppendText("\nВсе тесты завершены!");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("\nВсе тесты завершены!");
            RichTextBoxReader.AppendText("\nВсе тесты завершены!");
            RichTextBoxReader.AppendText(Environment.NewLine);
         }
         catch (WebException ex)
         {
            HttpWebResponse response = (HttpWebResponse)ex.Response;
            if (response != null)
            {
               TextBoxReader.AppendText("Ошибка HTTP: " + response.StatusCode + " - " + response.StatusDescription);
               TextBoxReader.AppendText(Environment.NewLine);
               ListBoxReader.Items.Add("Ошибка HTTP: " + response.StatusCode + " - " + response.StatusDescription);
               RichTextBoxReader.AppendText("Ошибка HTTP: " + response.StatusCode + " - " + response.StatusDescription);
               RichTextBoxReader.AppendText(Environment.NewLine);
               if (response.ContentLength > 0)
               {
                  using (Stream stream = response.GetResponseStream())
                  {
                     if (stream != null)
                     {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                           string errorBody = reader.ReadToEnd();
                           TextBoxReader.AppendText("Тело ошибки: " + errorBody);
                           TextBoxReader.AppendText(Environment.NewLine);
                           ListBoxReader.Items.Add("Тело ошибки: " + errorBody);
                           RichTextBoxReader.AppendText("Тело ошибки: " + errorBody);
                           RichTextBoxReader.AppendText(Environment.NewLine);
                        }
                     }
                  }
               }
            }
            else
            {
               TextBoxReader.AppendText("Ошибка: " + ex.Message);
               TextBoxReader.AppendText(Environment.NewLine);
               ListBoxReader.Items.Add("Ошибка: " + ex.Message);
               RichTextBoxReader.AppendText("Ошибка: " + ex.Message);
               RichTextBoxReader.AppendText(Environment.NewLine);
            }
         }
         catch (Exception ex)
         {
            TextBoxReader.AppendText("Неожиданная ошибка: " + ex.Message);
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("Неожиданная ошибка: " + ex.Message);
            RichTextBoxReader.AppendText("Неожиданная ошибка: " + ex.Message);
            RichTextBoxReader.AppendText(Environment.NewLine);
         }
      }

      void TestServerConnection()
      {
         try
         {
            Client.DownloadString(BaseUrl);
            TextBoxReader.AppendText("1. Сервер доступен");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("1. Сервер доступен");
            RichTextBoxReader.AppendText("1. Сервер доступен");
            RichTextBoxReader.AppendText(Environment.NewLine);
         }
         catch
         {
            TextBoxReader.AppendText("1. Сервер недоступен");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("1. Сервер недоступен");
            RichTextBoxReader.AppendText("1. Сервер недоступен");
            RichTextBoxReader.AppendText(Environment.NewLine);
            throw;
         }
      }

      void GetAllItems()
      {
         try
         {
            string response = Client.DownloadString(BaseUrl);
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(response);
            TextBoxReader.AppendText("Статус: Успешно");
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("Статус: Успешно");
            RichTextBoxReader.AppendText("Статус: Успешно");
            RichTextBoxReader.AppendText(Environment.NewLine);

            TextBoxReader.AppendText("Найдено элементов:" + items.Count);
            TextBoxReader.AppendText(Environment.NewLine);
            ListBoxReader.Items.Add("Найдено элементов:" + items.Count);
            RichTextBoxReader.AppendText("Найдено элементов:" + items.Count);
            RichTextBoxReader.AppendText(Environment.NewLine);

            if (items.Count > 0)
            {
               int i = 0;
               while (i < items.Count)
               {
                  Item item = items[i];
                  string wording = ("Date: {0:dd.MM.yyyy HH:mm:ss.fff}, Timestamp: {1}, ID: {2}, Производитель: {3}, Название: {4}, Цена: {5:F}",
                     item.Date, item.Timestamp, item.Id, item.Vendor, item.Name, item.Price).ToString();

                  TextBoxReader.AppendText(wording);

                  //TextBoxReader.AppendText("Date: {0:dd.MM.yyyy HH:mm:ss.fff}, Timestamp: {1}, ID: {2}, Производитель: {3}, Название: {4}, Цена: {5:F}",
                  //      item.Date, item.Timestamp, item.Id, item.Vendor, item.Name, item.Price);


                  TextBoxReader.AppendText(Environment.NewLine);

                  ListBoxReader.Items.Add("Найдено элементов:" + items.Count);
                  RichTextBoxReader.AppendText("Найдено элементов:" + items.Count);
                  RichTextBoxReader.AppendText(Environment.NewLine);


                  i++;
               }
            }
         }
         catch (WebException ex)
         {
            HandleWebException(ex);
         }
      }

      static Item CreateItem(Item item)
      {
         try
         {
            string json = JsonConvert.SerializeObject(item);
            string response = Client.UploadString(BaseUrl, "POST", json);
            Item createdItem = JsonConvert.DeserializeObject<Item>(response);
            //Console.WriteLine("Статус: Создано успешно");
            //Console.WriteLine("Date: {0:dd.MM.yyyy HH:mm:ss.fff}, Timestamp: {1}, ID: {2}, Производитель: {3}, Название: {4}, Цена: {5:F}",
            //   item.Date, item.Timestamp, item.Id, item.Vendor, item.Name, item.Price);
            return createdItem;
         }
         catch (WebException ex)
         {
            HandleWebException(ex);
            return null;
         }
      }

      static void GetItemById(int id)
      {
         try
         {
            string url = string.Format("{0}/{1}", BaseUrl, id);
            string response = Client.DownloadString(url);
            Item item = JsonConvert.DeserializeObject<Item>(response);
            //Console.WriteLine("Статус: Найден");
            //Console.WriteLine("Date: {0:dd.MM.yyyy HH:mm:ss.fff}, Timestamp: {1}, ID: {2}, Производитель: {3}, Название: {4}, Цена: {5:F}",
            //   item.Date, item.Timestamp, item.Id, item.Vendor, item.Name, item.Price);
         }
         catch (WebException ex)
         {
            HandleWebException(ex);
         }
      }

      static Item UpdateItem(int id, Item item)
      {
         try
         {
            string url = string.Format("{0}/{1}", BaseUrl, id);
            string json = JsonConvert.SerializeObject(item);
            string response = Client.UploadString(url, "PUT", json);
            Item updatedItem = JsonConvert.DeserializeObject<Item>(response);
            //Console.WriteLine("Статус: Обновлено успешно");
            //Console.WriteLine("Date: {0:dd.MM.yyyy HH:mm:ss.fff}, Timestamp: {1}, ID: {2}, Производитель: {3}, Название: {4}, Цена: {5:F}",
            //   item.Date, item.Timestamp, item.Id, item.Vendor, item.Name, item.Price);
            return updatedItem;
         }
         catch (WebException ex)
         {
            HandleWebException(ex);
            return null;
         }
      }

      static void DeleteItem(int id)
      {
         try
         {
            string url = string.Format("{0}/{1}", BaseUrl, id);
            string response = Client.UploadString(url, "DELETE", "");
            JObject result = JObject.Parse(response);
            //Console.WriteLine("Статус: Удалено успешно");
            //Console.WriteLine("Сообщение: {0}", result["message"]);
         }
         catch (WebException ex)
         {
            HandleWebException(ex);
         }
      }

      static void GetNonExistentItem(int id)
      {
         try
         {
            string url = string.Format("{0}/{1}", BaseUrl, id);
            Client.DownloadString(url);
            //Console.WriteLine("Статус: ОШИБКА - элемент найден (не должно было произойти)");
         }
         catch (WebException ex)
         {
            HttpWebResponse response = (HttpWebResponse)ex.Response;
            if (response != null)
            {
               if (response.StatusCode == HttpStatusCode.NotFound)
               {
                  //Console.WriteLine("Статус: Ожидаемая ошибка - элемент не найден");
               }
               else
               {
                  HandleWebException(ex);
               }
            }
            else
            {
               HandleWebException(ex);
            }
         }
      }

      static void DeleteNonExistentItem(int id)
      {
         try
         {
            string url = string.Format("{0}/{1}", BaseUrl, id);
            Client.UploadString(url, "DELETE", "");
            //Console.WriteLine("Статус: ОШИБКА - элемент удален (не должно было произойти)");
         }
         catch (WebException ex)
         {
            HttpWebResponse response = (HttpWebResponse)ex.Response;
            if (response != null)
            {
               if (response.StatusCode == HttpStatusCode.NotFound)
               {
                  //Console.WriteLine("Статус: Ожидаемая ошибка - элемент не найден");
               }
               else
               {
                  HandleWebException(ex);
               }
            }
            else
            {
               HandleWebException(ex);
            }
         }
      }

      static void TestInvalidData()
      {
         try
         {
            string invalidJson = "{invalid json}";
            Client.UploadString(BaseUrl, "POST", invalidJson);
            //Console.WriteLine("Статус: ОШИБКА - сервер принял невалидный JSON");
         }
         catch (WebException ex)
         {
            HttpWebResponse response = (HttpWebResponse)ex.Response;
            if (response != null)
            {
               if (response.StatusCode == HttpStatusCode.BadRequest)
               {
                  //Console.WriteLine("Статус: Ожидаемая ошибка - невалидные данные");
                  using (Stream stream = ex.Response.GetResponseStream())
                  {
                     if (stream != null)
                     {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                           string error = reader.ReadToEnd();
                           //Console.WriteLine("Сообщение об ошибке: {0}", error);
                        }
                     }
                  }
               }
               else
               {
                  HandleWebException(ex);
               }
            }
            else
            {
               HandleWebException(ex);
            }
         }
      }

      static void TestInvalidMethod()
      {
         try
         {
            Client.Headers[HttpRequestHeader.ContentType] = "application/json";
            Client.UploadString(BaseUrl, "PATCH", "{}");
            //Console.WriteLine("Статус: ОШИБКА - сервер принял неразрешенный метод");
         }
         catch (WebException ex)
         {
            HttpWebResponse response = (HttpWebResponse)ex.Response;
            if (response != null)
            {
               if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
               {
                  //Console.WriteLine("Статус: Ожидаемая ошибка - метод не разрешен");
               }
               else
               {
                  HandleWebException(ex);
               }
            }
            else
            {
               HandleWebException(ex);
            }
         }
      }

      static void HandleWebException(WebException ex)
      {
         HttpWebResponse response = (HttpWebResponse)ex.Response;
         if (response != null)
         {
            //Console.WriteLine("HTTP Ошибка: {0} {1}", (int)response.StatusCode, response.StatusCode);
            using (Stream stream = response.GetResponseStream())
            {
               if (stream != null)
               {
                  using (StreamReader reader = new StreamReader(stream))
                  {
                     string errorBody = reader.ReadToEnd();
                     if (!string.IsNullOrEmpty(errorBody))
                     {
                        //Console.WriteLine("Тело ошибки: {0}", errorBody);
                     }
                  }
               }
            }
         }
         else
         {
            //Console.WriteLine("Ошибка: {0}", ex.Message);
         }
      }

      private void ButtonClear_Click(object sender, System.EventArgs e)
      {
         TextBoxReader.Clear();
         RichTextBoxReader.Clear();
         ListBoxReader.Items.Clear();
      }
   }
}