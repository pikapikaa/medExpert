using System;
using System.Collections.Generic;
using System.Text;

namespace medExpert.Models
{
    /// <summary>
    /// Класс ключей сообщений для MessageCenter
    /// </summary>
    public static class MessageKeys
    {
        /// <summary>
        /// Сообщение события изменения даты начала проверок
        /// </summary>
        public const string AddStructuralUnit = nameof(AddStructuralUnit);

        /// <summary>
        /// Сообщение события сортировки по возрастанию
        /// </summary>
        public const string AscendingSort = nameof(AscendingSort);

        /// <summary>
        /// Сообщение события сортировки по убыванию
        /// </summary>
        public const string DescendingSort = nameof(DescendingSort);

        /// <summary>
        /// Сообщение события сортировки по дате
        /// </summary>
        public const string DateSort = nameof(DateSort);

        /// <summary>
        /// Сообщение события сортировки по умолчанию
        /// </summary>
        public const string DefaultSort = nameof(DefaultSort);

        /// <summary>
        /// Сообщение события выбора фото из галереи
        /// </summary>
        public const string PickPhoto = nameof(PickPhoto);

        /// <summary>
        /// Сообщение события удаления фото
        /// </summary>
        public const string DeletePhoto = nameof(DeletePhoto);

        /// <summary>
        /// Сообщение события обновления списка изображений на детальном представлении
        /// </summary>
        public const string RefreshImageList = nameof(RefreshImageList); 
    }
}
