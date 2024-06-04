using Business.IMP;
using BusinessServices.Services;
using DataAccessServices.Services;
using DomainModel.DTO.Conversation;
using DomainModel.DTO.Employee;
using DomainModel.DTO.Message;
using DomainModel.DTO.User;
using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace AdminPannel.Controllers
{

    public class MessageController : Controller
    {
        private readonly IMessageBusiness _messageBusiness;
        private readonly IUserMessageBusiness _userMessageBusiness;
        private readonly IUserBusiness _userBusiness;
        private readonly IConversationBusiness _conversationBusiness;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly IConversationMessageBusiness _conversationMessageBusiness;
        private readonly IRoleBusiness _roleBusiness;


        public MessageController(IMessageBusiness messageBusiness, IUserMessageBusiness userMessageBusiness, IUserBusiness userBusiness, IConversationBusiness conversationBusiness, IEmployeeBusiness employeeBusiness, IConversationMessageBusiness conversationMessageBusiness, IRoleBusiness roleBusiness)
        {
            _messageBusiness = messageBusiness;
            _userMessageBusiness = userMessageBusiness;
            _userBusiness = userBusiness;
            _conversationBusiness = conversationBusiness;
            _employeeBusiness = employeeBusiness;
            _conversationMessageBusiness = conversationMessageBusiness;
            _roleBusiness = roleBusiness;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllMessageViewComponent()
        {
            return ViewComponent("GetAllMessage");
        }




        [HttpGet]
        public IActionResult GetAllMessage()
        {
            var result = new List<MessageNotRead>();
            var x = 10;
            var messages = _messageBusiness.GetAll();
            foreach (var message in messages)
            {

                var userMessageSearchModel = new UserMessage
                {
                    MessageId = message.MessageId,
                };
                var userMessageList = _userMessageBusiness.Search(userMessageSearchModel, out x).MainResults;
                if (userMessageList.Count != 0)
                {
                    foreach (var userMessage in userMessageList)
                    {
                        var user = _userBusiness.Get(userMessage.UserId);
                        if (user != null)
                        {
                            var MessageNotRead = new MessageNotRead
                            {
                                userName = user.FirstName + " " + user.LastName,
                                messageBody = message.MessageBody,
                                messageHeader = message.MessageHeader,
                                messageId = message.MessageId,
                                MessageTime = message.MessageTime,

                            };
                            if (message.Read == true)
                            {
                                MessageNotRead.Status = " خوانده شده ";
                            }
                            else
                            {
                                MessageNotRead.Status = " خوانده نشده ";
                            }
                            result.Add(MessageNotRead);
                        }

                    }
                }


            }
            return View(result);
        }


        [HttpGet]
        public IActionResult AddMessage()
        {
            var roleList = _roleBusiness.GetAll();
            ViewBag.role = new SelectList(roleList, "RoleName", "RoleName");
            return View();
        }

        [HttpPost]
        public IActionResult AddMessage(MessageAddEditModel model)
        {
            model.MessageTime= DateTime.Now;
            model.Read = false;
            var x = 10;
            if (model.Target=="کارمندان")
            {
                var search = new UserSearchModel
                {
                    RoleName = "کارمندان"
                };
                var searchResult = _userBusiness.GetUserBuRole(model.Target);
                var result = _messageBusiness.Add(model);
                if (result.Success==false)
                {
                    return Json(" افزودن ادرس با خطا همراه بود ");
                }
                else
                {
                    foreach (var item in searchResult)
                    {
                        var userMessage = new UserMessage
                        {
                            UserId = item.UserId,
                            MessageId = result.RecordId
                        };
                        var res = _userMessageBusiness.Add(userMessage);
                        if (res.Success == false)
                        {
                            return Json(" افزودن جدول واسط با خطا همراه بود ");
                        }
                        else
                        {
                            return Json(" افزودن پیام موفقیت امیز بود ");
                        }
                    }
                }
                
            }
            if (model.Target == "کاربران")
            {
                var search = new UserSearchModel
                {
                    RoleName = "کاربران"
                };
                var searchResult = _userBusiness.GetUserBuRole(model.Target);
                var result = _messageBusiness.Add(model);
                if (result.Success == false)
                {
                    return Json(" افزودن ادرس با خطا همراه بود ");
                }
                else
                {
                    foreach (var item in searchResult)
                    {
                        var userMessage = new UserMessage
                        {
                            UserId = item.UserId,
                            MessageId = result.RecordId
                        };
                        var res = _userMessageBusiness.Add(userMessage);
                        if (res.Success == false)
                        {
                            return Json(" افزودن جدول واسط با خطا همراه بود ");
                        }
                        else
                        {
                            return Json(" افزودن پیام موفقیت امیز بود ");
                        }
                    }
                }
                
            }
            else
            {
                var searchResult = _userBusiness.GetAll();
                var result = _messageBusiness.Add(model);
                if (result.Success == false)
                {
                    return Json(" افزودن ادرس با خطا همراه بود ");
                }
                foreach (var item in searchResult)
                {
                    var userMessage = new UserMessage
                    {
                        UserId = item.UserId,
                        MessageId = result.RecordId
                    };
                    var res = _userMessageBusiness.Add(userMessage);
                    if (res.Success == false)
                    {
                        return Json(" افزودن جدول واسط با خطا همراه بود ");
                    }
                }
                
            }

            return Json("");

        }


        [HttpGet]
        public IActionResult UpdateMessage(int id)
        {
            var result = _messageBusiness.Get(id);
            var messageAddEditModel = new MessageAddEditModel
            {
                MessageBody = result.MessageBody,
                MessageHeader = result.MessageHeader,
                MessageId = result.MessageId,
                MessageTime = result.MessageTime,
                Read = result.Read,
            };
            return View(messageAddEditModel);
        }

        [HttpPost]
        public IActionResult UpdateMessage(MessageAddEditModel model)
        {
            var result = _messageBusiness.Update(model);
            return Json(result);
        }


        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var result = _messageBusiness.Delete(id);
            return Json(result);
        }





















        [HttpGet]
        public IActionResult NotReadMessage()
        {
            var result = new List<MessageNotRead>();
            var x = 10;
            var messages = _messageBusiness.GetAll();
            foreach (var message in messages)
            {
                if (message.Read == false)
                {
                    var userMessageSearchModel = new UserMessage
                    {
                        MessageId = message.MessageId,
                    };
                    var userMessageList = _userMessageBusiness.Search(userMessageSearchModel, out x).MainResults;
                    if (userMessageList.Count != 0)
                    {
                        foreach (var userMessage in userMessageList)
                        {
                            var user = _userBusiness.Get(userMessage.UserId);
                            if (user != null)
                            {
                                var MessageNotRead = new MessageNotRead
                                {
                                    userName = user.FirstName + " " + user.LastName,
                                    messageBody = message.MessageBody,
                                    messageHeader = message.MessageHeader,
                                    messageId = message.MessageId
                                };
                                result.Add(MessageNotRead);
                            }

                        }
                    }
                }

            }

            return ViewComponent("MessageNotRead", result);
        }
    }
}
