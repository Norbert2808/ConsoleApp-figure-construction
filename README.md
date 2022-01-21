# PersonalProject1

Project 1, theme 2.

Консольное приложение для рисования, где пользователь может добавлять, удалять и двигать фигуры (линии, треугольники, прямоугольники, круги), строя изображения.

- Каждый раз, когда изображение редактируется, оно обновляется на экране.
- Каждая фигура нарисована как символы, представляющие ее индекс глубины в сцене.
- Можно упорядочить фигуры в порядке возрастания/уменьшения по площади/периметру.
- Можно рисовать заполненные фигуры или только их контуры.
- Можно хранить/загружать сцены в файл/из файла

## Структура исходного кода
Каталог с решением имеет следующую структуру :
- **.editorconfig** - файл с правилами форматирования кода;
- **.gitignore** - скрывает файлы и папки от системы контроля версий Git;
- **.gitlab-ci.yml** - конфигурация GitLab CI/CD;
- **README.md** - этот файл;
- **Project1.sln** - файл решения для открытия в предпочитаемой IDE;
- **Project1** - директория с кодом проекта;
    - **ConsoleApp.cs** - основной класс приложения, который обрабатывает первый запрос пользователя;
    - **ConsolePoint.cs** - класс консольная точка;
    - **Menu.cs** - класс Menu для удобства работы с консолью;
    - **PaintValidation.cs** - класс валидация рисования, для валидной отрисовки фигур;
    - **Program.cs** - класс-точка входа в приложения; 
    - **Helpers** - директория с основной логикой приложения;
        - **AddHelper.cs** - класс с логикой добавления фигур;
        - **AddValidation.cs** - класс с валидацией для добавления фигур;
        - **DeleteHelper.cs** - класс с логикой удаления фигур;
        - **MoveHelper.cs** - класс с логикой перемещения фигур;
        - **SaveHelper.cs** - класс с логикой сохранения фигур в файл;
        - **SortHelper.cs** - класс с логикой сортировки фигур;
        - **StatisticsHelper.cs** - класс с логикой статистики фигур;
    - **Shapes** - директория с классами фигур;
        - **Circle.cs** - класс круг, унаследован от ConsoleShape;
        - **ConsoleShape.cs** - базовый абстрактний клас консольная фигура;
        - **Line.cs** - класс линия, унаследован от ConsoleShape;
        - **Rectangle.cs** - класс прямоугольник, унаследован от ConsoleShape;
        - **Triangle.cs** - класс треугольник, унаследован от ConsoleShape;
    - **Example of addition shapes** - директория с примером добавления фигур;
        - **Circles.jpg** - фотография с примером для класса Circle;
        - **Input.txt** - пример входных данных;
        - **Lines.jpg** - фотография с примером для класса Line;
        - **Rectangles.jpg** - фотография с примером для класса Rectangl;
        - **Triangles.jpg** - фотография с примером для класса Triangl;
- **Hw2.Tests** - тестовый проект;

## Добавления фигур
Bниз по сцене - положительная ось y, вправо - положительная ось x.
После удачного добавления сцена обновляется.
Все входящие данные должны передаваться только в указаном порядке через `, `.

### Добавления круга
Входние дание: 
- `startPosX`, `startPosY` - левая верхняя точка описаного квадрата(каждая `[0;100]`);
- `radius` - радиус круга(`[1;25]`);
- `color` - enum цвет для рисования(`Blue`, `Red`, `Gray`, `Magenta`, `Yellow`, `DarkGray`...);
- `filling` - заполненность фигури(`true`, `false`).

### Добавления прямоугольника
Входние дание: 
- `startPosX`, `startPosY` - левая верхняя точка прямоугольника(каждая `[0;100]`);
- `width` - ширина прямоугольника(`[0;100]`);
- `width` - высота прямоугольника(`[0;100]`);
- `color` - enum цвет для рисования(`Blue`, `Red`, `Gray`, `Magenta`, `Yellow`, `DarkGray`...);
- `filling` - заполненность фигури(`true`, `false`).

### Добавления треугольника
Mожно добавлять только прямоугольный равнобедренный треугольник.
Входние дание: 
- `AX`, `AY`, `BX`, `BY`, `CX`, `CY` - координаты трех точек A, B, C(каждая `[0;100]`);
- `color` - enum цвет для рисования(`Blue`, `Red`, `Gray`, `Magenta`, `Yellow`, `DarkGray`...);
- `filling` - заполненность фигури(`true`, `false`).

### Добавления линии
Можно добавлять только прямые или диагональные линии.
Входние дание: 
- `AX`, `AY`, `BX`, `BY` - координаты двух точек A, B(каждая `[0;100]`);
- `color` - enum цвет для рисования(`Blue`, `Red`, `Gray`, `Magenta`, `Yellow`, `DarkGray`...).

## Удаления фигур
После удачного удаления сцена обновляется.
Входние дание: 
- `index` - индекс для удаления(`[0; figureLenght - 1]`).

## Перемещения фигур
Вверх и влево можна перемещать фигуры только к границам сцены.
Вниз и вправо можна выходит за границы, будет видна только часть фигури, что находитса в сцене.
После удачного перемещения сцена обновляется.
Все входящие данные должны передаваться только в указаном порядке через `, `.
Входние дание: 
- `index` - индекс фигури для удаления(`[0; figureLenght - 1]`);
- `side` - enum сторона(`Up`, `Down`, `Left`, `Right`);
- `number` - на сколько переместить(`[0;100]`).

## Сохранения фигур
Фигури сохраняются в файл `scene.txt`.

## Сортировка фигур
Можно сортировать по периметру (количество граничных символов)/площади (количество символов), по возрастанию/убыванию.
В незаполнених фигурах или у линии периметр = площади.
После удачной сортировкив сцена обновляется.
Все входящие данные должны передаваться только в указаном порядке через `, `.
Входние дание: 
- `x` - тип сортировки(`p` - периметр, `a` - площа);
- `y` - тип сортировки(`a` - по возрастанию, `d` - по убыванию);

## Статистика фигур
Показывает статистику по свойствам фигур.