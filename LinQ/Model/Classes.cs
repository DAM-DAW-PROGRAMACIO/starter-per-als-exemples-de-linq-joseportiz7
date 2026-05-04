using System;
using System.Collections.Generic;
using System.Text;

namespace LinQ.Model
{

    #region Model de dades
    //  JERARQUIA:
    //  ElementMultimedia (base)
    //    ├─ Llibre
    //    ├─ Pelicula
    //    └─ Canco


    /// <summary>
    /// Classe base per a tots els elements multimèdia
    /// </summary>
    public abstract class ElementMultimedia
    {
        public string Titol { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Any { get; set; }
        public List<string> Etiquetes { get; set; } = new List<string>();
    }

    /// <summary>
    /// Representa un llibre
    /// </summary>
    public class Llibre : ElementMultimedia
    {
        public string Genere { get; set; } = string.Empty;
        public int Pagines { get; set; }
        public string Editorial { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Titol} - {Autor} ({Any}) - {Pagines} pàg.";
        }
    }

    /// <summary>
    /// Representa una pel·lícula
    /// </summary>
    public class Pelicula : ElementMultimedia
    {
        public string Director { get; set; } = string.Empty;
        public int DuradaMinuts { get; set; }
        public string Genere { get; set; } = string.Empty;
        public double Valoracio { get; set; } // De 0 a 10

        public override string ToString()
        {
            return $"{Titol} - {Director} ({Any}) - {DuradaMinuts} min - {Valoracio}";
        }
    }

    /// <summary>
    /// Representa una cançó
    /// </summary>
    public class Canco : ElementMultimedia
    {
        public string Artista { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public int DuradaSegons { get; set; }
        public string Genere { get; set; } = string.Empty;

        public override string ToString()
        {
            int minuts = DuradaSegons / 60;
            int segons = DuradaSegons % 60;
            return $"{Titol} - {Artista} ({Album}) - {minuts}:{segons:D2}";
        }
    }

    /// <summary>
    /// Biblioteca que conté tots els elements multimèdia
    /// </summary>
    public class Biblioteca
    {
        private List<ElementMultimedia> _elements = new List<ElementMultimedia>();

        public IEnumerable<ElementMultimedia> Elements => _elements;

        public void AfegeixElement(ElementMultimedia element)
        {
            _elements.Add(element);
        }

        public int Count => _elements.Count;
    }

#endregion

    #region Generador de dades fake

    /// <summary>
    /// Classe per generar dades de prova hardcodejades
    /// </summary>
    public static class GeneradorDades
    {
        public static Biblioteca CreaBiblioteca()
        {
            var biblioteca = new Biblioteca();

            // Llibres
            biblioteca.AfegeixElement(new Llibre
            {
                Titol = "El Senyor dels Anells",
                Autor = "J.R.R. Tolkien",
                Any = 1954,
                Pagines = 1178,
                Genere = "Fantasia",
                Editorial = "Allen & Unwin",
                Etiquetes = new List<string> { "fantasia", "aventura", "clàssic", "meravella" }
            });

            biblioteca.AfegeixElement(new Llibre
            {
                Titol = "1984",
                Autor = "George Orwell",
                Any = 1949,
                Pagines = 328,
                Genere = "Distopia",
                Editorial = "Secker & Warburg",
                Etiquetes = new List<string> { "distopia", "política", "clàssic" }
            });

            biblioteca.AfegeixElement(new Llibre
            {
                Titol = "Cent anys de solitud",
                Autor = "Gabriel García Márquez",
                Any = 1967,
                Pagines = 417,
                Genere = "Realisme màgic",
                Editorial = "Sudamericana",
                Etiquetes = new List<string> { "realisme màgic", "clàssic", "família" }
            });

            biblioteca.AfegeixElement(new Llibre
            {
                Titol = "Harry Potter i la pedra filosofal",
                Autor = "J.K. Rowling",
                Any = 1997,
                Pagines = 223,
                Genere = "Fantasia",
                Editorial = "Bloomsbury",
                Etiquetes = new List<string> { "fantasia", "aventura", "màgia", "infantil" }
            });

            biblioteca.AfegeixElement(new Llibre
            {
                Titol = "El Hobbit",
                Autor = "J.R.R. Tolkien",
                Any = 1937,
                Pagines = 310,
                Genere = "Fantasia",
                Editorial = "Allen & Unwin",
                Etiquetes = new List<string> { "fantasia", "aventura", "infantil" }
            });

            biblioteca.AfegeixElement(new Llibre
            {
                Titol = "Dune",
                Autor = "Frank Herbert",
                Any = 1965,
                Pagines = 688,
                Genere = "Ciència-ficció",
                Editorial = "Chilton Books",
                Etiquetes = new List<string> { "ciència-ficció", "aventura", "política" }
            });

            biblioteca.AfegeixElement(new Llibre
            {
                Titol = "La volta al món en 80 dies",
                Autor = "Jules Verne",
                Any = 1873,
                Pagines = 167,
                Genere = "Aventura",
                Editorial = "Pierre-Jules Hetzel",
                Etiquetes = new List<string> { "aventura", "viatge", "clàssic" }
            });

            // Pel·lícules
            biblioteca.AfegeixElement(new Pelicula
            {
                Titol = "Inception",
                Autor = "Christopher Nolan",
                Director = "Christopher Nolan",
                Any = 2010,
                DuradaMinuts = 148,
                Genere = "Ciència-ficció",
                Valoracio = 8.8,
                Etiquetes = new List<string> { "ciència-ficció", "thriller", "somnis" }
            });

            biblioteca.AfegeixElement(new Pelicula
            {
                Titol = "El Padrí",
                Autor = "Francis Ford Coppola",
                Director = "Francis Ford Coppola",
                Any = 1972,
                DuradaMinuts = 175,
                Genere = "Drama",
                Valoracio = 9.2,
                Etiquetes = new List<string> { "drama", "crim", "clàssic", "màfia" }
            });

            biblioteca.AfegeixElement(new Pelicula
            {
                Titol = "Interstellar",
                Autor = "Christopher Nolan",
                Director = "Christopher Nolan",
                Any = 2014,
                DuradaMinuts = 169,
                Genere = "Ciència-ficció",
                Valoracio = 8.6,
                Etiquetes = new List<string> { "ciència-ficció", "espai", "viatge" }
            });

            biblioteca.AfegeixElement(new Pelicula
            {
                Titol = "Pulp Fiction",
                Autor = "Quentin Tarantino",
                Director = "Quentin Tarantino",
                Any = 1994,
                DuradaMinuts = 154,
                Genere = "Crim",
                Valoracio = 8.9,
                Etiquetes = new List<string> { "crim", "drama", "clàssic" }
            });

            biblioteca.AfegeixElement(new Pelicula
            {
                Titol = "Matrix",
                Autor = "The Wachowskis",
                Director = "The Wachowskis",
                Any = 1999,
                DuradaMinuts = 136,
                Genere = "Ciència-ficció",
                Valoracio = 8.7,
                Etiquetes = new List<string> { "ciència-ficció", "acció", "filosofia" }
            });

            biblioteca.AfegeixElement(new Pelicula
            {
                Titol = "El rescat del soldat Ryan",
                Autor = "Steven Spielberg",
                Director = "Steven Spielberg",
                Any = 1998,
                DuradaMinuts = 169,
                Genere = "Bèl·lic",
                Valoracio = 8.6,
                Etiquetes = new List<string> { "bèl·lic", "drama", "història" }
            });

            // Cançons
            biblioteca.AfegeixElement(new Canco
            {
                Titol = "Bohemian Rhapsody",
                Autor = "Queen",
                Artista = "Queen",
                Album = "A Night at the Opera",
                Any = 1975,
                DuradaSegons = 354,
                Genere = "Rock",
                Etiquetes = new List<string> { "rock", "clàssic", "òpera" }
            });

            biblioteca.AfegeixElement(new Canco
            {
                Titol = "Hotel California",
                Autor = "Eagles",
                Artista = "Eagles",
                Album = "Hotel California",
                Any = 1976,
                DuradaSegons = 391,
                Genere = "Rock",
                Etiquetes = new List<string> { "rock", "clàssic", "viatge" }
            });

            biblioteca.AfegeixElement(new Canco
            {
                Titol = "Imagine",
                Autor = "John Lennon",
                Artista = "John Lennon",
                Album = "Imagine",
                Any = 1971,
                DuradaSegons = 183,
                Genere = "Pop",
                Etiquetes = new List<string> { "pop", "clàssic", "pau" }
            });

            biblioteca.AfegeixElement(new Canco
            {
                Titol = "Stairway to Heaven",
                Autor = "Led Zeppelin",
                Artista = "Led Zeppelin",
                Album = "Led Zeppelin IV",
                Any = 1971,
                DuradaSegons = 482,
                Genere = "Rock",
                Etiquetes = new List<string> { "rock", "clàssic", "èpic" }
            });

            biblioteca.AfegeixElement(new Canco
            {
                Titol = "Smells Like Teen Spirit",
                Autor = "Nirvana",
                Artista = "Nirvana",
                Album = "Nevermind",
                Any = 1991,
                DuradaSegons = 301,
                Genere = "Grunge",
                Etiquetes = new List<string> { "grunge", "rock", "rebel·lió" }
            });

            biblioteca.AfegeixElement(new Canco
            {
                Titol = "Billie Jean",
                Autor = "Michael Jackson",
                Artista = "Michael Jackson",
                Album = "Thriller",
                Any = 1982,
                DuradaSegons = 294,
                Genere = "Pop",
                Etiquetes = new List<string> { "pop", "dance", "clàssic" }
            });

            biblioteca.AfegeixElement(new Canco
            {
                Titol = "Sweet Child O' Mine",
                Autor = "Guns N' Roses",
                Artista = "Guns N' Roses",
                Album = "Appetite for Destruction",
                Any = 1987,
                DuradaSegons = 356,
                Genere = "Rock",
                Etiquetes = new List<string> { "rock", "clàssic", "amor" }
            });

            biblioteca.AfegeixElement(new Canco
            {
                Titol = "One",
                Autor = "U2",
                Artista = "U2",
                Album = "Achtung Baby",
                Any = 1991,
                DuradaSegons = 276,
                Genere = "Rock",
                Etiquetes = new List<string> { "rock", "esperança", "unitat" }
            });

            return biblioteca;
        }
}
    #endregion
}
