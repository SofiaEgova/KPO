using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Forms
{
    public static class LetterTemplates
    {
        public static string updatePasswordLetter(string login)
        {
            return login + ", ваш пароль изменен!";
        }

        public static string addToProject(string login, string projectTitle)
        {
            return login + ", вас добавили к проекту "+projectTitle;
        }

        public static string addTask(string login, string taskTitle)
        {
            return login + ", вам назначили задачу " + taskTitle;
        }
    }
}
