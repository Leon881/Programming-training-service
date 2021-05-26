using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutoTests
{

    public class Programming_training_service
    {
        public ChromeDriver driver;
        public WebDriverWait wait;

        private readonly By mainMenuLocator = By.ClassName("main-menu");
        private readonly By loginButtonLocator = By.ClassName("auth");
        private readonly By inputLoginLocator = By.Id("Email");
        private readonly By inputpasswordLocator = By.Id("Password");
        private readonly By submitButtonLocator = By.ClassName("submit-button");
        private readonly By loginTextLocator = By.CssSelector(".profile > span ");
        private readonly By logoutButtonLocator = By.ClassName("logout");
        private readonly By authButtonLocator = By.ClassName("auth");
        private readonly By registerButtonLocator = By.ClassName("regist");
        private readonly By settingsButtonLocator = By.ClassName("setting-button");
        private readonly By authorsPageLocator = By.ClassName("main-authors-container");
        private readonly By authorsMenuButtonLocator = By.Id("authors");
        private readonly By notesPageLocator = By.ClassName("main-notes-field");
        private readonly By notesMenuButtonLocator = By.Id("notes");
        private readonly By createNoteLocator = By.ClassName("create-ref");
        private readonly By addNoteLocator = By.ClassName("button-note");
        private readonly By notesModalLocator = By.Id("modal");
        private readonly By articlePageLocator = By.ClassName("article-field");
        private readonly By articleTextLocator = By.CssSelector("#app > div > main > div > div.learning-content > div.learning-text > div > div");
        private readonly By articlesPageLocator = By.ClassName("main-articles-menu");
        private readonly By articlesMenuButtonLocator = By.Id("articles");
        private readonly By articlesListItemLocator = By.ClassName("article-item");
        private readonly By languageMenuLocator = By.ClassName("main-language-menu");
        private readonly By languageMenuItemsLocator = By.ClassName("language-menu-list__item");
        private readonly By learningMenuButtonLocator = By.Id("learningMenu");
        private readonly By learningPageLocator = By.ClassName("main-learning-page");
        private readonly By learningAccordionMenuLocator = By.ClassName("menu");
        private readonly By learningContentLocator = By.ClassName("learning-content");
        private readonly By testsMenuButtonLocator = By.Id("testsMenu");
        private readonly By testsListLocator = By.ClassName("main-tests-navigation");
        private readonly By testsLocator = By.ClassName("test-ref");
        private readonly By testResultLocator = By.ClassName("resultTest");
        private readonly By testPageLocator = By.ClassName("main-test-area");
        private readonly By noteLocator = By.ClassName("note-form");
        private readonly By backButton = By.ClassName("back-ref");
        private readonly By titleRef = By.ClassName("title-ref");
        private readonly By submitTestLocator = By.ClassName("end-button");
        private readonly By resutlTestModalLocator = By.Id("modalResult");
        private readonly string login = "vadim";
        private readonly string password = "12345";
        
        
        //Вспомогательная функция, совершающая авторизацию
        private void GetAuth()
        {
            driver.FindElement(loginButtonLocator).Click();
            driver.FindElement(inputLoginLocator).SendKeys(login);
            driver.FindElement(inputpasswordLocator).SendKeys(password);
            driver.FindElement(submitButtonLocator).Click();
        }

        private void RevealMainMenu()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(mainMenuLocator));
            action.Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        private void PassTest()
        {
            driver.FindElement(By.XPath("//*[@id='question 1']/div[1]/div[2]/div/label[3]/p/input")).Click();
            driver.FindElement(By.XPath("//*[@id='question 2']/div[1]/div[2]/div/label[4]/p/input")).Click();
            driver.FindElement(By.XPath("//*[@id='3']")).SendKeys("Create table");
            driver.FindElement(By.XPath("//*[@id='question 4']/div[1]/div[2]/div/label[1]/p/input")).Click();
            driver.FindElement(submitTestLocator).Click();
            wait.Until(e => e.FindElement(resutlTestModalLocator).GetCssValue("opacity") == "1");
        }

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Navigate().GoToUrl("https://vamtrainingservice.somee.com/");
        }


        [Test]
        public void TrainingService_MainMenuWithoutAuth_Exists()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(mainMenuLocator).Displayed, "Главное меню не отображается");
                Assert.AreEqual("auto",driver.FindElement(articlesMenuButtonLocator).GetCssValue("pointer-events"), "Блок статей не активен");
                Assert.AreEqual("none", driver.FindElement(notesMenuButtonLocator).GetCssValue("pointer-events"), "Блок заметок активен до авторизации");
                Assert.AreEqual("auto", driver.FindElement(learningMenuButtonLocator).GetCssValue("pointer-events"), "Блок изучения не активен");
                Assert.AreEqual("none", driver.FindElement(testsMenuButtonLocator).GetCssValue("pointer-events"), "Блок тестов активен до авторизации");
                Assert.AreEqual("auto", driver.FindElement(authorsMenuButtonLocator).GetCssValue("pointer-events"), "Блок про авторов не активен");
            });
        }

        [Test]
        public void TrainingService_MainMenuWithAuth_Exists()
        {
            GetAuth();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(mainMenuLocator).Displayed, "Главное меню не отображается");
                Assert.AreEqual("auto", driver.FindElement(articlesMenuButtonLocator).GetCssValue("pointer-events"), "Блок статей не активен");
                Assert.AreEqual("auto", driver.FindElement(notesMenuButtonLocator).GetCssValue("pointer-events"), "Блок заметок не активен после авторизации");
                Assert.AreEqual("auto", driver.FindElement(learningMenuButtonLocator).GetCssValue("pointer-events"), "Блок изучения не активен");
                Assert.AreEqual("auto", driver.FindElement(testsMenuButtonLocator).GetCssValue("pointer-events"), "Блок тестов не активен после авторизации");
                Assert.AreEqual("auto", driver.FindElement(authorsMenuButtonLocator).GetCssValue("pointer-events"), "Блок про авторов не активен");
            });
        }

        [Test]
        public void TrainingService_LoginAndRegisterButtonsWithoutAuth_Exist()
        {
            Assert.Multiple(() =>
           {
               Assert.IsTrue(driver.FindElement(authButtonLocator).Displayed, "Кнопка входа не отображается");
               Assert.IsTrue(driver.FindElement(registerButtonLocator).Displayed, "Кнопка регистрации не отображается");
           });
           
        }

        [Test]
        public void TrainingService_LogoutButton_Work()
        {
            GetAuth();
            driver.FindElement(logoutButtonLocator).Click();
            bool el;
            try
            {
                driver.FindElement(loginTextLocator);
                driver.FindElement(logoutButtonLocator);
                el = true;
            }
            catch (NoSuchElementException ex)
            {
                el = false;
            }
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(authButtonLocator).Displayed, "Кнопка входа не отображается");
                Assert.IsTrue(driver.FindElement(registerButtonLocator).Displayed, "Кнопка регистрации не отображается");
                Assert.IsFalse(el, "Отображаются кнопки выхода или логин");
            });
        }

        [Test]
        public void TrainingService_SettingButtonsWithAdmin_Exist()
        {
            GetAuth();
            Assert.IsTrue(driver.FindElement(settingsButtonLocator).Displayed, "Кнопка настроек не отображается");
        }

        [Test]
        public void TrainingService_SettingButtonsWithoutAdmin_Absent()
        {
            driver.FindElement(loginButtonLocator).Click();
            driver.FindElement(inputLoginLocator).SendKeys("vadKor");
            driver.FindElement(inputpasswordLocator).SendKeys("12345");
            driver.FindElement(submitButtonLocator).Click();
            bool el;
            try
            {
                driver.FindElement(settingsButtonLocator);
                el = true;
            }
            catch (NoSuchElementException ex)
            {
                el = false;
            }
            Assert.IsFalse(el, "Кнопка настроек отображается при отсутсвие прав администратора");
        }

        [Test]
        public void TrainingService_GoToArticlesPage_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(articlesMenuButtonLocator).Click();
            Assert.IsTrue(driver.FindElement(articlesPageLocator).Displayed, "Страница статей не отображается");
        }

        [Test]
        public void TrainingService_ArticlesPage_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(articlesMenuButtonLocator).Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(mainMenuLocator).Displayed, "Возвращение на главное меню не произошло");
        }

        [Test]
        public void TrainingService_LanguageLearningMenu_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(learningMenuButtonLocator).Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(mainMenuLocator).Displayed, "Возвращение на главное меню не произошло");
        }

        [Test]
        public void TrainingService_LanguageTestMenu_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(mainMenuLocator).Displayed, "Возвращение на главное меню не произошло");
        }

        [Test]
        public void TrainingService_NotesPage_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(notesMenuButtonLocator).Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(mainMenuLocator).Displayed, "Возвращение на главное меню не произошло");
        }

        [Test]
        public void TrainingService_AuthorsPage_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(authorsMenuButtonLocator).Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(mainMenuLocator).Displayed, "Возвращение на главное меню не произошло");
        }

        [Test]
        public void TrainingService_GoToTestPage_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            driver.FindElements(testsLocator).First().Click();
            Assert.IsTrue(driver.FindElement(testPageLocator).Displayed, "Страница с тестом не открылась");
        }

        [Test]
        public void TrainingService_TestPageCheckEmptyInput_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            driver.FindElements(testsLocator).First().Click();
            driver.FindElement(submitTestLocator).Click();
            Assert.AreEqual("0", driver.FindElement(resutlTestModalLocator).GetCssValue("opacity"), "Нет проверки на заполненность");
        }

        [Test]
        public void TrainingService_PassTest_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).Last().Click();
            driver.FindElements(testsLocator).Last().Click();
            PassTest();
            Assert.Multiple(() =>
            {
                Assert.AreEqual("1", driver.FindElement(resutlTestModalLocator).GetCssValue("opacity"), "Окно с результатом не появилось");
                Assert.AreEqual("Ваш результат - 75 % правильных ответов", driver.FindElement(testResultLocator).Text,
                "Результат неправильно подсчитан");
            });
        }

        [Test]
        public void TrainingService_SaveTestResut_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).Last().Click();
            driver.FindElements(testsLocator).Last().Click();
            PassTest();
            driver.FindElement(By.ClassName("close-test")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='11']")).Text.Contains("75"), "Рейтинг пройденного теста не сохранился");
        }

        [Test]
        public void TrainingService_StayButtonInTestResult_Works()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).Last().Click();
            driver.FindElements(testsLocator).Last().Click();
            PassTest();
            driver.FindElement(By.ClassName("stay")).Click();
            wait.Until(e => e.FindElement(resutlTestModalLocator).GetCssValue("opacity") == "0");
            Assert.Multiple(() =>
            {
                Assert.AreEqual("0", driver.FindElement(resutlTestModalLocator).GetCssValue("opacity"), "Окно с результатом не закрылось");
                Assert.IsTrue(driver.FindElement(testPageLocator).Displayed, "Остались не на странице с тестом");
            });
          
        }

        [Test]
        public void TrainingService_CloseButtonAddNoteModal_Works()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(notesMenuButtonLocator).Click();
            driver.FindElement(createNoteLocator).Click();
            driver.FindElement(By.ClassName("close-note")).Click();
            wait.Until(e => e.FindElement(notesModalLocator).GetCssValue("opacity") == "0");
            Assert.AreEqual("0", driver.FindElement(notesModalLocator).GetCssValue("opacity"), "Окно добавления заметки не закрылось");
        }

        [Test]
        public void TrainingService_OpenArticle_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(articlesMenuButtonLocator).Click();
            driver.FindElements(articlesListItemLocator).First().Click();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(articlePageLocator).Displayed, "Страницы с открытой статьей не отображается");
                Assert.IsTrue(driver.FindElement(articleTextLocator).Displayed, "Статья не загрузилась");
            });
        }

        [Test]
        public void TrainingService_OpenLearningPage_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(learningMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(learningPageLocator).Displayed, "Страницы обучения не отображается");
                Assert.IsTrue(driver.FindElement(learningAccordionMenuLocator).Displayed, "Боковое меню не отображается");
                Assert.IsTrue(driver.FindElement(learningContentLocator).Displayed, "Поле обучения не отображается");
            });
        }

        [Test]
        public void TrainingService_StartLearning_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(learningMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            driver.FindElement(By.CssSelector("#app > div > main > div > div.main-learning-container > div.learning-container > div > div:nth-child(1)")).Click();
            wait.Until(e => e.FindElement(By.ClassName("open-sub-menu")).Displayed);
            driver.FindElement(By.XPath("//*[@id='1,1']")).Click();
            Assert.IsTrue(driver.FindElement(By.Id("content_center")).Displayed, "Текст для обучения не загрузился");
        }

        [Test]
        public void TrainingService_OpenTestsList_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            Assert.IsTrue(driver.FindElement(testsListLocator).Displayed, "Страница с тестами не отображается");
        }

        [Test]
        public void TrainingService_TestsList_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(languageMenuLocator).Displayed, "Возвращение на страницу выбора языка не произошло");
        }

        [Test]
        public void TrainingService_TestPage_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            driver.FindElements(testsLocator).First().Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(testsListLocator).Displayed, "Возвращение на страницу выбора теста не произошло");
        }

        [Test]
        public void TrainingService_ArticlePage_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(articlesMenuButtonLocator).Click();
            driver.FindElements(articlesListItemLocator).First().Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(articlesPageLocator).Displayed, "Возвращение на страницу выбора статьи не произошло");
        }

        [Test]
        public void TrainingService_LearningPage_GetBack()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(learningMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            driver.FindElement(backButton).Click();
            Assert.IsTrue(driver.FindElement(languageMenuLocator).Displayed, "Возвращение на страницу выбора языка не произошло");
        }

        [Test]
        public void TrainingService_PushTitle_GetBackToMainMenu()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(learningMenuButtonLocator).Click();
            driver.FindElements(languageMenuItemsLocator).First().Click();
            driver.FindElement(titleRef).Click();
            Assert.IsTrue(driver.FindElement(mainMenuLocator).Displayed, "Возвращение на главную не произошло");
        }

        [Test]
        public void TrainingService_OpenModalForAddNoteFromLearningArea_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(articlesMenuButtonLocator).Click();
            driver.FindElements(articlesListItemLocator).First().Click();
            driver.FindElement(addNoteLocator).Click();
            wait.Until(e => e.FindElement(notesModalLocator).GetCssValue("opacity") == "1");
            Assert.AreEqual("1", driver.FindElement(notesModalLocator).GetCssValue("opacity"), "Не отображается окно добавления заметки");
        }

        [Test]
        public void TrainingService_GoToLanguageLearningMenu_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(learningMenuButtonLocator).Click();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(languageMenuLocator).Displayed, "Страница выбора языка не отображается");
                Assert.IsTrue(driver.FindElements(languageMenuItemsLocator).First().FindElement(By.CssSelector("a")).Text.Contains("ОБУЧЕНИЕ"),
                    "Отображаются неверные пункты меню");
            });
        }

        [Test]
        public void TrainingService_GoToLanguageTestsMenu_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(testsMenuButtonLocator).Click();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(driver.FindElement(languageMenuLocator).Displayed, "Страница выбора языка не отображается");
                Assert.IsTrue(driver.FindElements(languageMenuItemsLocator).First().FindElement(By.CssSelector("a")).Text.Contains("ТЕСТЫ"),
                    "Отображаются неверные пункты меню");
            });
        }

        [Test]
        public void TrainingService_GoToAuthorsPage_Success()
        {
            RevealMainMenu();
            driver.FindElement(authorsMenuButtonLocator).Click();
            Assert.IsTrue(driver.FindElement(authorsPageLocator).Displayed, "Страница авторов не отображается");
        }

        [Test]
        public void TrainingService_GoToNotesPage_Success()
        {
            GetAuth();
            RevealMainMenu();
            driver.FindElement(notesMenuButtonLocator).Click();
            Assert.IsTrue(driver.FindElement(notesPageLocator).Displayed, "Страница заметок не отображается");
        }

        [Test]
        public void TrainingService_CreateNotes_Success()
        {      
            var title = "Тестовое название!";
            var text = "Тестовый текст!";
            GetAuth();
            RevealMainMenu();
            driver.FindElement(notesMenuButtonLocator).Click();
            var lastAmount = driver.FindElements(noteLocator).Count();
            driver.FindElement(createNoteLocator).Click();
            driver.FindElementById("note-title").SendKeys(title);
            driver.FindElementById("note-text").SendKeys(text);
            driver.FindElementByClassName("save-note").Click();
            driver.Navigate().Refresh();
            Assert.Multiple(() =>{
            Assert.AreEqual(lastAmount + 1, driver.FindElements(noteLocator).Count(), "Заметка не добавилась");
            Assert.AreEqual(title, driver.FindElements(noteLocator).Last().
                FindElement(By.ClassName("note-title")).Text, "Название заметки не совпадает с введенным");
            Assert.AreEqual(text, driver.FindElements(noteLocator).Last().
                FindElement(By.ClassName("note-text")).Text, "Текст заметки не совпадает с введенным");
            });
        }

        [Test]
        public void TrainingService_Authorization_Succes()
        {
            GetAuth();
            bool el ;
            try
            {
                driver.FindElement(authButtonLocator);
                driver.FindElement(registerButtonLocator);
                el = true;
            }
            catch (NoSuchElementException ex)
            {
                el = false;
            }
            Assert.Multiple(() => {
                Assert.AreEqual(login, driver.FindElement(loginTextLocator).Text, 
                    "Имя пользователя не отображается");
                Assert.IsTrue(driver.FindElement(logoutButtonLocator).Displayed, "Кнопка выхода отсутствует");
                Assert.IsFalse(el, "Отображаются кнопки входа или регистрации");
            });
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


    }
}
