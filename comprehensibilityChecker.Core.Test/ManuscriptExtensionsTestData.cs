using System;
using System.Collections.Generic;
using comprehensibilityChecker.Contracts;
using comprehensibilityChecker.Contracts.Data;

namespace comprehensibilityChecker.Core.Test
{
    public class ManuscriptExtensionsTestData
    {
        public static IEnumerable<object[]> AverageSentenceLengthData =>
            new List<object[]>
            {
                new object[]
                {
                    new Manuscript(
                        new[]
                        {
                            new Sentence(
                                new[]
                                {
                                    "a",
                                    "b."
                                }),
                            new Sentence(
                                new[]
                                {
                                    "c",
                                    "de",
                                    "f!"
                                })
                        }, "a b. c de f!"),
                    6.0
                },
                new object[]
                {
                    new Manuscript(
                        new[]
                        {
                            new Sentence(
                                new[]
                                {
                                    "a,",
                                    "b?"
                                }),
                            new Sentence(
                                new[]
                                {
                                    "c",
                                    "de;",
                                    "f!"
                                })
                        }, "a, b? c de; f!"),
                    7.0
                },
                new object[]
                {
                    new Manuscript(
                        new[]
                        {
                            new Sentence(
                                new[]
                                {
                                    "a,",
                                    "b"
                                })
                        }, "a, b"),
                    4.0
                },
                new object[]
                {
                    new Manuscript(
                        new[]
                        {
                            new Sentence(
                                new[]
                                {
                                    "a",
                                    "b",
                                    "c",
                                    "d."
                                })
                        }, $@"a b{Environment.NewLine}c d."),
                    8.0
                }
            };

        public static IEnumerable<object[]> AverageWordLengthData =>
            new List<object[]>
            {
                new object[]
                {
                    new Manuscript(
                        new[]
                        {
                            new Sentence(
                                new[]
                                {
                                    "Es",
                                    "blaut",

                                    "die",
                                    "Nacht,",
                                    "die",
                                    "Sternlein",
                                    "blinken."
                                })
                        }, "Es blaut die Nacht, die Sternlein blinken."),
                    6.5
                },
                new object[]
                {
                    new Manuscript(
                        new[]
                        {
                            new Sentence(
                                new[]
                                {
                                    "Hund",
                                    "und",
                                    "Katzen!"
                                })
                        }, "Hund und Katzen!"),
                    5.0
                }
            };

        public static IEnumerable<object[]> WordCountData =>
        new List<object[]>
        {
            new object[]
            {
                new Manuscript(
                    new []
                    {
                        new Sentence(
                            new []
                            {
                                "Es",
                                "blaut",
                                "die",
                                "Nacht,",
                                "die",
                                "Sternlein",
                                "blinken."
                            }),
                        new Sentence(
                            new []
                            {
                                "Schneeflöcklein",
                                "leis",
                                "herunter",
                                "sinken."
                            })
                    }, "Es blaut die Nacht, die Sternlein blinken. Schneeflöcklein leis herunter sinken."), 8
            },
            new object[]
            {
                new Manuscript(
                    new []
                    {
                        new Sentence(
                            new []
                            {
                                "Der",
                                "ADAC,",
                                "dein",
                                "Freund",
                                "und",
                                "Helfer"
                            })
                    }, "Der ADAC, dein Freund und Helfer"), 3
            },
            new object[]
            {
                new Manuscript(
                    new []
                    {
                        new Sentence(
                            new []
                            {
                                "der,",
                                "auf"
                            })
                    }, "der, auf"), 0
            }
            
        };
    }
}
