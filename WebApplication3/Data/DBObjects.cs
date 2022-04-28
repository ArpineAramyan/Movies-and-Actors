using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Data.Models;
using System;

namespace WebApplication3.Data
{
    public class DBObjects
    {
        //vsyo static chtobi mogli iz drugix classov obr syuda
        public static void Initial(AppDBContent content)
        {
            if (!content.Actors.Any())
            {
                content.AddRange(
                    new Actor
                    {
                        Rating = 923,
                        Name = "ТимотиШаламе",
                        Image = "/img/atim.jpg",
                        AboutActor = "тот самый с персиками",
                        Movies = "МаленькиеЖенщины Дюна Король",
                    },
                    new Actor
                    {
                        Rating = 841,
                        Name = "Зендея",
                        Image = "/img/azen.jpg",
                        AboutActor = "раньше тебе не нравилась, а сейчас твоя любимица",
                        Movies = "Дюна",
                    },
                    new Actor
                    {
                        Rating = 718,
                        Name = "РобертПаттинсон",
                        Image = "/img/arobp.jpg",
                        AboutActor = "да-да, эдвард из сумерек",
                        Movies = "Король",
                    },
                    new Actor
                    {
                        Rating = 889,
                        Name = "ИтанХоук",
                        Image = "/img/aitan.jpg",
                        AboutActor = "о, где-то я его видел",
                        Movies = "ОбществоМёртвыхПоэтов ПатрульВремени",
                    },
                    new Actor
                    {
                        Rating = 900,
                        Name = "РобинУильямс",
                        Image = "/img/arobw.jpg",
                        AboutActor = "л у ч ш и й",
                        Movies = "ОбществоМёртвыхПоэтов",
                    }
                    );
            }

            if (!content.Movies.Any())
            {
                content.AddRange(
                    new Movie
                    {
                        Name = "ОбществоМёртвыхПоэтов",
                        ShortDescription = "если вы не посмотрите, я обижусь",
                        Image = "/img/obshchestvo-mertvikh-poetov.jpg",
                        Actors = "РобинУильямс ИтанХоук",
                        Release = 1989,
                        Rating = 872,
                    },
                    new Movie
                    {
                        Name = "МаленькиеЖенщины",
                        ShortDescription = "необыкновенная атмосфера",
                        Image = "/img/lit_wom.jpg",
                        Actors = "ТимотиШаламе",
                        Release = 2019,
                        Rating = 705,
                    },
                    new Movie
                    {
                        Name = "Дюна",
                        ShortDescription = "трёхчасовая красивая картинка со сложностью О(n^4)",
                        Image = "/img/du.jpg",
                        Actors = "ТимотиШаламе Зендея",
                        Release = 2021,
                        Rating = 372,
                    },
                    new Movie
                    {
                        Name = "Король",
                        ShortDescription = "исторический фильм про короля (ого! неожиданно)",
                        Image = "/img/king.jpg",
                        Actors = "ТимотиШаламе РобертПаттинсон",
                        Release = 2019,
                        Rating = 548,
                    },
                    new Movie
                    {
                        Name = "ПатрульВремени",
                        ShortDescription = "я сам свой дед",
                        Image = "/img/pv.jpg",
                        Actors = "ИтанХоук",
                        Release = 2014,
                        Rating = 691,
                    }
                    );
            }
            content.SaveChanges();
        }
    }
}
