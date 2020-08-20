using System;

namespace AraratDictionary
{
    public interface INotification
    {
        void CreateNotification(String title, String message);
    }
}