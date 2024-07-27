using CRudAppUsingAspWebApiClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CRudAppUsingAspWebApiClient.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7047/api/StudentAPI/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        //[Route("GetAllStudents")]
        public IActionResult Index()
        {
            List<Student> student = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url + "GetAllStudents").Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);

        }
        [HttpGet]
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url + "InsertStudent", content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Student Added...";
                //string test = "Student Added...";
                return RedirectToAction("Index");
            }
            return View();
        }





        //[HttpPost]
        //public async Task<IActionResult> Create(Student std)
        //{
        //    // Ensure the model is valid
        //    if (!ModelState.IsValid)
        //    {
        //        return View(std);
        //    }

        //    try
        //    {
        //        string data = JsonConvert.SerializeObject(std);
        //        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

        //        // Assuming 'client' is a properly initialized HttpClient instance
        //        HttpResponseMessage response = await client.PostAsync(url + "InsertStudent", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            TempData["insert_message"] = "Student Added...";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            // Log the response status code and reason
        //            TempData["insert_message"] = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        //            return View(std);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception
        //        TempData["insert_message"] = $"Exception: {ex.Message}";
        //        return View(std);
        //    }
        //}


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url+ "GetStudentById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {

                 string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }

            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + "UpdateStudentById/" + std.studentId, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["Update_message"] = "Student Updated ";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + "GetStudentById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {

                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }

            return View(std);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + "GetStudentById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {

                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }

            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConformed(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.DeleteAsync(url+"DeleteStudentById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {

                TempData["Delete_message"] = "Student Deleted... ";
                return RedirectToAction("Index");

            }

            return View();
        }
    }
}
