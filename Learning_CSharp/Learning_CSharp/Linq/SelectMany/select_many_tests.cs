using System.Collections.Generic;
using System.Linq;
using Learning_CSharp.FauxDomain;
using NUnit.Framework;

namespace Learning_CSharp.Linq.SelectMany
{
    [TestFixture]
    public class select_many_tests
    {
        [SetUp]
        public void setup()
        {
            var ship1 = new Starship("Chimera");
            ship1.Fighters.AddRange(new[]
                                        {
                                            new Fighter(),
                                            new Fighter(),
                                            new Fighter(),
                                        });
            var ship2 = new Starship("Executor");
            ship2.Fighters.AddRange(new[]
                                        {
                                            new Fighter(),
                                            new Fighter(),
                                        });
            var ship3 = new Starship("Intrepid");
            ship3.Fighters.AddRange(new[]
                                        {
                                            new Fighter(),
                                            new Fighter(),
                                            new Fighter(),
                                            new Fighter(),
                                            new Fighter(),
                                        });

            _starships = new[] {ship1, ship2, ship3};
        }

        IEnumerable<Starship> _starships;

        [Test]
        public void return_list_of_all_fighters()
        {
            // [ Chimera ]  has [Fighter],[Fighter],[Fighter]
            // [ Executor ] has [Fighter],[Fighter]
            // [ Intrepid ] has [Fighter],[Fighter],[Fighter],[Fighter],[Fighter]

            IEnumerable<Fighter> fighters = _starships.SelectMany(s => s.Fighters);

            // [ Fighter ]
            // [ Fighter ]
            // [ Fighter ]
            // [ Fighter ]
            // [ Fighter ]
            // [ Fighter ]
            // [ Fighter ]
            // [ Fighter ]
            // [ Fighter ]
            // [ Fighter ]

            fighters.Count().ShouldBe(10);
        }

        [Test]
        public void return_list_of_fighters_with_name()
        {
            // [ Chimera ]  has [Fighter],[Fighter],[Fighter]
            // [ Executor ] has [Fighter],[Fighter]
            // [ Intrepid ] has [Fighter],[Fighter],[Fighter],[Fighter],[Fighter]

            var fighters = _starships.SelectMany(s => s.Fighters, (s, f) => new {s.Name, Fighter = f});
            
            // [ Chimera - Fighter ]
            // [ Chimera - Fighter ]
            // [ Chimera - Fighter ]
            // [ Executor - Fighter ]
            // [ Executor - Fighter ]
            // [ Intrepid - Fighter ]
            // [ Intrepid - Fighter ]
            // [ Intrepid - Fighter ]
            // [ Intrepid - Fighter ]
            // [ Intrepid - Fighter ]


            fighters.Count().ShouldBe(10);
            fighters.Where(f => f.Name == "Chimera").Count().ShouldBe(3);
        }

        [Test]
        public void should_have_correct_children_count()
        {
            // [ Chimera ]  has [Fighter],[Fighter],[Fighter]
            // [ Executor ] has [Fighter],[Fighter]
            // [ Intrepid ] has [Fighter],[Fighter],[Fighter],[Fighter],[Fighter]

            _starships.ElementAt(0).Fighters.Count.ShouldBe(3);
            _starships.ElementAt(1).Fighters.Count.ShouldBe(2);
            _starships.ElementAt(2).Fighters.Count.ShouldBe(5);
        }

        [Test]
        public void should_have_correct_parent_count()
        {
            // [ Chimera ]  has [Fighter],[Fighter],[Fighter]
            // [ Executor ] has [Fighter],[Fighter]
            // [ Intrepid ] has [Fighter],[Fighter],[Fighter],[Fighter],[Fighter]

            _starships.Count().ShouldBe(3);
        }
    }
}