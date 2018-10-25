Original publication: <a href="https://infostart.ru/public/143405/" target="_blank">https://infostart.ru/public/143405/</a>
<hr/>
<h1>Согласование документов 1С:Документооборот и 1С:Консолидация из Outlook 2010-2013 без запуска 1С</h1>
<div><strong>Надстройки для Outlook 2010-2013, позволяющие пользователю без запуска 1С оперативно выполнять согласование документов при поступлении оповещения на электронную почту.<br>
Поддерживается интеграция с 1С:Документооборот ПРОФ и КОРП (работа с процессом "Согласование" с поддержкой просмотра файлов по внутренним и исходящим документам) и 1С:Консолидация ПРОФ (согласование "Заявок на расходование средств" и "Экземпляров отчетов" с возможностью просмотра печатных форм).</strong></div>
<div><p>Позволяет облегчить работу некоторым пользователям по согласованию назначенных им документов в 1С.<br>Пользователь получает возможность оперативно просмотреть ключевую информацию по документу и сразу же согласовать или отклонить его.</p>
<p>Надстройки реализованы отдельно для 1С:Консолидация и 1С:Документооборот, поэтому могут использоваться как вместе, так и по отдельности.</p>
<p>Общий функционал:<br>1) Согласование или отклонение документа с комментариями:<br>&nbsp; для 1С:Документооборот - процесс "Согласование"<br>&nbsp; для 1С:Консолидация - "Заявка на расходование средств" и "Экземпляр отчета"<br>2) Просмотр истории согласования (в том числе, по уже обработанным документам).<br>3) Автоматическое формирование оповещения в Outlook о приближении крайней даты согласования документа.</p>
<p>Дополнительно для 1С:Документооборот:<br>1) Просмотр и корректировка приложенных к "Внутреннему документу" и "Исходящему документу" файлов.<br>2) Создание процесса "Поручение" на основании любого письма с возможностью передать в 1С вложенные в письмо файлы.</p>
<p>Дополнительно для 1С:Консолидация ПРОФ:<br>1) Просмотр печатных форм "Заявки на расходование средств" и "Экземляра отчета"</p>
<p>Для работы надстроек требуется внесение изменений в в конфигурации 1С и публикация web-сервисов (интеграция с 1С выполняется через веб-сервисы, что обеспечивает очень высокую скорость работы). Установить веб-сервер и опубликовать web-сервисы достаточно просто и не требует дополнительных затрат на лицензии.</p>
<p><strong>Для работы надстроек требуется установленный NET Framework 4.0.</strong> Загрузить его можно бесплатно <span style="text-decoration: underline;"><a href="https://www.microsoft.com/ru-ru/download/details.aspx?id=17718">здесь</a></span>.</p>
<p>Установка надстройки выполняется <span style="text-decoration: underline;">без административных прав пользователем самостоятельно</span>.<br>Следует учесть, что надстройки устанавливаются из того каталога, из которого они были запущены, поэтому необходимо сразу копировать каталоги с надстройками на постоянное место (например, в "Мои документы")</p>
<p>После установки надстроек требуется указать местоположение 1С - адрес веб-сервиса, а также параметры доступа к нему - доменная авторизация, либо по обычному логину и паролю. <span style="text-decoration: underline;">Это нужно сделать отдельно для каждой из надстроек.</span></p>
<p><span style="text-decoration: underline; color: #0000ff;"><strong>Обновление от 01.09.2012</strong></span><br><span style="color: #0000ff;">1) для надстройки разрешена работа по http-протоколу</span><br><span style="color: #0000ff;">2) приложен новый cfu-файл с изменениями для релиза 1С:Документооборот КОРП 1.2.5.3 (updateDoc8_1.2.5.3.cfu)</span></p>
<p><span style="text-decoration: underline; color: #0000ff;"><strong>Обновление от 10.03.2013</strong></span><br><span style="color: #0000ff;">1) создана надстройка для 1С:Консолидация. cfu-файл собран для релиза 1С:Консолидация ПРОФ 2.1.2.1</span><br><span style="color: #0000ff;">2) в надстройку для 1С:Документооборот добавлен функционал формирования поручений на основании письма</span><br><span style="color: #0000ff;">3) приложен новый cfu-файл с изменениями для релиза 1С:Документооборот КОРП 1.2.8.1 и ПРОФ 1.2.8.1<br>4) все файлы собраны в один архив и приложены к статье<br>5) пароль пользователя для доступа к 1С при вводе скрывается<br>6) исправлено несколько ошибок, влиящих на стабильность работы надстроек<br></span></p>
<p>&nbsp;<span style="text-decoration: underline; color: #0000ff;"><strong>Обновление от 08.09.2013<br></strong></span><span style="color: #0000ff;">Выложил исходники для Visual Studio 2012</span><span style="text-decoration: underline; color: #0000ff;"><strong><br></strong></span></p>
<p>&nbsp;</p>
<h2><strong>Настройки на сервере:</strong></h2>
<p>1) внести в конфигурацию необходимые доработки из cfu-файла обновления<br>2) опубликовать на веб-сервере веб-сервис "ALP_OutlookServices"<br>3) Если для пользователей будет использоваться обычная авторизация, а не доменная, то для пользователей, которые будут работать через надстройку, необходимо изменить имя пользователя в конфигураторе на латиницу. <strong>С кириллитическим именем авторизоваться на веб-сервисе пользователи не смогут!</strong></p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/1.png?raw=true" alt=""/></p>
<p>&nbsp;</p>
<h2>Настройка на клиентской рабочей станции:</h2>
<p>1) Распаковать дистрибутив с надстройкой, например, в "Мои документы" на компьютере пользователя.<br>2) Запустить файл setup.exe и подтвердить установку надстройки:</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/2.png?raw=true" alt=""/></p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/3.png?raw=true" alt=""/></p>
<p>3) запустить Outlook, открыть любое входящее письмо, перейти на соответствующую закладку (для 1С:Консолидации или 1С:Документооборота) и нажать кнопку "Настройка параметров соединения"</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%BD%D0%B0%D1%81%D1%82%D1%80%D0%BE%D0%B9%D0%BA%D0%B0.png?raw=true" alt=""/></p>
<p>4) заполнить адрес web-сервиса, способ аутентификации и логин/пароль (<strong>пароль хранится в реестре Windows в открытом виде!</strong>)</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/5.png?raw=true" alt=""/></p>
<p>5) нажать "ОК", при этом система проверит подключение к web-сервису. При возникновении ошибки выдаст предупреждение, в случае успеха - тихо закроется.</p>
<p>&nbsp;</p>
<h2>Работа с надстройкой:</h2>
<p>1) Во входящих письмах от 1С автоматически устанавливается красный флажок и оповещение о приближении крайнего срока выполнения:</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/6.png?raw=true" alt=""/></p>
<p>2) При просмотре самого письма в его нижней части отображаются кнопки для выполнения операций: согласование, отклонение, просмотр истории согласования, а также управление файлами.</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/7.png?raw=true" alt=""/></p>
<p>3) При нажатии кнопок "Согласовано" или "Отклонено" отображается окно для ввода комментария. После нажатия в нем "ОК" выполняется соответствующая операция и отображается ее результат. После успешного выполнения операции эти 2 кнопки в основной форме письма блокируются от дальнейших нажатий:</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/81.png?raw=true" alt=""/></p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/82.png?raw=true" alt=""/></p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/83.png?raw=true" alt=""/></p>
<p>&nbsp;</p>
<p>4) Кнопка "История согласования" (только для 1С:Документооборот) позволяет посмотреть аналогичный стандартный отчет 1С.</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/9.png?raw=true" alt=""/></p>
<p>5) Кнопка "Файлы" (только для 1С:Документооборот) открывает отдельное окно, позволяющее (первое открытие может занять несколько секунд, т.к. файлы загружаются из Документооборота):</p>
<p>5.1) Открыть документы на просмотр</p>
<p>5.2) Захватить документы на редактирование (в Документообороте при этом файл отмечается "занятым" текущим пользователем)</p>
<p>5.3) Поместить скорректированные документы обратно в базу</p>
<p>5.4) Отменить захват документов</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/10.png?raw=true" alt=""/></p>
<p>6) Для создания поручения в 1С:Документооборот на основании письма необходимо:<br>6.1) Открыть требуемое входящее письмо, перейти на закладку "1С:Документооборот 8" и нажать кнопку "Создать поручение на основе письма"<br><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%9F%D0%BE%D1%80%D1%83%D1%87%D0%B5%D0%BD%D0%B8%D0%B51.png?raw=true" alt=""/></p>
<p>6.2) Указать пользователя - Поручение будет назначено тому пользователю, полное наименование которого будет указано в поле "Кому". Для облегчения выбора пользователя возможно набрать первые буквы фамилии, затем нажать "Загрузить". Если система обнаружит только 1 такого пользователя, то он будет подставлен сразу. Если несколько - необходимо будет уточнить конкретного пользователя из выпадающего списка.<br>Если же поле "Кому" оставить пустым и нажать кнопку "Загрузить", то выпадающий список будет заполнен всеми пользователями "1С:Документооборот". С одной стороны, это может быть удобно для выбора, но, с другой стороны, может сказаться на быстродействии при большом числе пользователей.<br><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%9F%D0%BE%D1%80%D1%83%D1%87%D0%B5%D0%BD%D0%B8%D0%B52.png?raw=true" alt=""/></p>
<p>6.3) При необходимости скорректировать Тему, Описание, Срок и Важность. Выбрать передаваемые вложения и нажать "Создать поручение".<br><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%9F%D0%BE%D1%80%D1%83%D1%87%D0%B5%D0%BD%D0%B8%D0%B53.png?raw=true" alt=""/></p>
<p>6.4) Если поручение было создано успешно, то в письмо будет добавлен соответствующий комментарий.<br> <img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%9F%D0%BE%D1%80%D1%83%D1%87%D0%B5%D0%BD%D0%B8%D0%B54.png?raw=true" alt=""/>
</p>
<p>В "1С:Документооборот" будет создан соответствующий документ с прикрепленными файлами:<br><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%9F%D0%BE%D1%80%D1%83%D1%87%D0%B5%D0%BD%D0%B8%D0%B55.png?raw=true" alt=""/></p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%9F%D0%BE%D1%80%D1%83%D1%87%D0%B5%D0%BD%D0%B8%D0%B56.png?raw=true" alt=""/> </p>
<p>&nbsp;</p>
<p>7) Во входящих письмах от "1С:Консолидация" есть возможность просмотра:<br>печатной формы "Заявки на расходование средств":
 <br>
<img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%9F%D0%B5%D1%87%D0%A4%D0%BE%D1%80%D0%BC%D0%B0%D0%97%D0%B0%D1%8F%D0%B2%D0%BA%D0%B8.png?raw=true" alt=""/>  
  </p>
<p>печатной формы "Экземпляра отчета" в том виде, как он доступен пользователю в 1С:</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%9F%D0%B5%D1%87%D0%A4%D0%BE%D1%80%D0%BC%D0%B0%D0%91%D1%8E%D0%B4%D0%B6%D0%B5%D1%82%D0%B0.png?raw=true" alt=""/></p>
<p>печатной формы отчета "История согласования":</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D0%98%D1%81%D1%82%D0%BE%D1%80%D0%B8%D1%8F%D0%A1%D0%BE%D0%B3%D0%BB%D0%B0%D1%81%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F.png?raw=true" alt=""/></p>
<p>&nbsp;</p>
<h2>Удаление надстроек с пользовательской рабочей станции:</h2>
<p>Производится под обычными пользовательскими правами из панели управления в обычном порядке.</p>
<p><img style="border: 1px solid black;" src="https://github.com/alekseybochkov/outlook-addin-for-1c-enterprise/blob/master/pics/%D1%83%D0%B4%D0%B0%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5.png?raw=true" alt=""/></p>
</div>
