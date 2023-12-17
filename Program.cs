using System;
using System.Reflection;
using System.Collections.Generic;
using DZ7;


/* Разработайте атрибут позволяющий методу ObjectToString сохранять поля классов с использованием произвольного имени.

Метод StringToObject должен также уметь работать с этим атрибутом для записи значение в свойство по имени его атрибута.

[CustomName(“CustomFieldName”)]
public int I = 0.

Если использовать формат строки с данными использованной нами для предыдущего примера то пара ключ значение для свойства I выглядела бы CustomFieldName:0

Подсказка:

Если GetProperty(propertyName) вернул null то очевидно свойства с таким именем нет и возможно имя является алиасом заданным с помощью CustomName. 
Возможно, если перебрать все поля с таким атрибутом то для одного из них propertyName = совпадает с таковым заданным атрибутом.*/




public class Program
{
    public static void Main()
    {
        var myObject = new ExampleClass { I = 42, S = "Hello" };

        // Сериализация
        var serializedData = Serializer.ObjectToString(myObject);
        Console.WriteLine(serializedData);

        // Десериализация
        var newObj = new ExampleClass();
        Serializer.StringToObject("CustomFieldName:100\nS:NewString", newObj);
        Console.WriteLine($"I: {newObj.I}, S: {newObj.S}");
    }
}