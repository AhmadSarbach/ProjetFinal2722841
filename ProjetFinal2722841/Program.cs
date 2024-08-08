using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetFinalAQL
{
    public class Etudiant
    {
        private int numeroEtudiant;
        private string nomEtudiant;
        private string prenomEtudiant;

        public int NumeroEtudiant
        {
            get { return numeroEtudiant; }
            set { numeroEtudiant = value; }
        }

        public string NomEtudiant
        {
            get { return nomEtudiant; }
            set { nomEtudiant = value; }
        }

        public string PrenomEtudiant
        {
            get { return prenomEtudiant; }
            set { prenomEtudiant = value; }
        }

        public Etudiant(int numeroEtudiant, string nomEtudiant, string prenomEtudiant)
        {
            this.numeroEtudiant = numeroEtudiant;
            this.nomEtudiant = nomEtudiant;
            this.prenomEtudiant = prenomEtudiant;
        }
    }

    public class Cours
    {
        private int numeroCours;
        private string codeCours;
        private string titreCours;

        public int NumeroCours
        {
            get { return numeroCours; }
            set { numeroCours = value; }
        }

        public string CodeCours
        {
            get { return codeCours; }
            set { codeCours = value; }
        }

        public string TitreCours
        {
            get { return titreCours; }
            set { titreCours = value; }
        }

        public Cours(int numeroCours, string codeCours, string titreCours)
        {
            this.numeroCours = numeroCours;
            this.codeCours = codeCours;
            this.titreCours = titreCours;
        }
    }

    public class Notes
    {
        private double noteCours;
        private int numeroEtudiant;
        private int numeroCours;

        public double NoteCours
        {
            get { return noteCours; }
            set { noteCours = value; }
        }

        public int NumeroEtudiant
        {
            get { return numeroEtudiant; }
            set { numeroEtudiant = value; }
        }

        public int NumeroCours
        {
            get { return numeroCours; }
            set { numeroCours = value; }
        }

        public Notes(double noteCours, int numeroEtudiant, int numeroCours)
        {
            this.noteCours = noteCours;
            this.numeroEtudiant = numeroEtudiant;
            this.numeroCours = numeroCours;
        }
    }

    internal class Program
    {
        private static List<Etudiant> etudiants = new List<Etudiant>();
        private static List<Cours> cours = new List<Cours>();
        private static List<Notes> notes = new List<Notes>();

        public static void Main(string[] args)
        {
            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("Choisissez une option :");
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Ajouter un cours");
                Console.WriteLine("3. Saisir une note");
                Console.WriteLine("4. Afficher les étudiants");
                Console.WriteLine("5. Afficher les cours");
                Console.WriteLine("6. Afficher les notes");
                Console.WriteLine("7. Afficher le relevé de notes d'un étudiant");
                Console.WriteLine("8. Quitter");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterEtudiant();
                        break;
                    case "2":
                        AjouterCours();
                        break;
                    case "3":
                        SaisirNote();
                        break;
                    case "4":
                        AfficherEtudiants();
                        break;
                    case "5":
                        AfficherCours();
                        break;
                    case "6":
                        AfficherNotes();
                        break;
                    case "7":
                        AfficherReleveDeNotes();
                        break;
                    case "8":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Option non valide.");
                        break;
                }
            }
        }

        private static void AjouterEtudiant()
        {
            try
            {
                Console.WriteLine("Veuillez entrer le numéro de l'étudiant:");
                int numeroEtudiant = int.Parse(Console.ReadLine());
                Console.WriteLine("Veuillez entrer le nom de l'étudiant:");
                string nom = Console.ReadLine();
                Console.WriteLine("Veuillez entrer le prénom de l'étudiant:");
                string prenom = Console.ReadLine();

                // Vérifie si l'étudiant existe déjà
                if (etudiants.Any(e => e.NumeroEtudiant == numeroEtudiant))
                {
                    Console.WriteLine("Un étudiant avec ce numéro existe déjà.");
                    return;
                }

                etudiants.Add(new Etudiant(numeroEtudiant, nom, prenom));
                Console.WriteLine("Étudiant ajouté avec succès.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Erreur de format : Entrez le format correct");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }

        private static void AjouterCours()
        {
            try
            {
                Console.WriteLine("Veuillez entrer le numéro du cours:");
                int numeroCours = int.Parse(Console.ReadLine());
                Console.WriteLine("Veuillez entrer le code du cours:");
                string code = Console.ReadLine();
                Console.WriteLine("Veuillez entrer le titre du cours:");
                string titre = Console.ReadLine();

                // Vérifie si le cours existe déjà
                if (cours.Any(c => c.NumeroCours == numeroCours))
                {
                    Console.WriteLine("Un cours avec ce numéro existe déjà.");
                    return;
                }

                cours.Add(new Cours(numeroCours, code, titre));
                Console.WriteLine("Cours ajouté avec succès.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Erreur de format : Entrez le format correct");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }

        private static void SaisirNote()
        {
            try
            {
                Console.WriteLine("Veuillez entrer la note:");
                double note = double.Parse(Console.ReadLine());
                Console.WriteLine("Veuillez entrer le numéro de l'étudiant:");
                int numeroEtudiant = int.Parse(Console.ReadLine());
                Console.WriteLine("Veuillez entrer le numéro du cours:");
                int numeroCours = int.Parse(Console.ReadLine());

                // Vérifie si l'étudiant et le cours existent
                if (!etudiants.Any(e => e.NumeroEtudiant == numeroEtudiant))
                {
                    Console.WriteLine("L'étudiant n'existe pas.");
                    return;
                }

                if (!cours.Any(c => c.NumeroCours == numeroCours))
                {
                    Console.WriteLine("Le cours n'existe pas.");
                    return;
                }

                notes.Add(new Notes(note, numeroEtudiant, numeroCours));
                SauvegarderDonnees(numeroEtudiant);
                Console.WriteLine("Note saisie avec succès.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erreur de format : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }

        private static void AfficherEtudiants()
        {
            Console.WriteLine("Liste des étudiants :");
            if (etudiants.Count == 0)
            {
                Console.WriteLine("Aucun étudiant à afficher.");
                return;
            }

            foreach (var etudiant in etudiants)
            {
                Console.WriteLine($"Numéro : {etudiant.NumeroEtudiant}," +
                    $" Nom : {etudiant.NomEtudiant}, Prénom : {etudiant.PrenomEtudiant}");
            }
        }

        private static void AfficherCours()
        {
            Console.WriteLine("Liste des cours :");
            if (cours.Count == 0)
            {
                Console.WriteLine("Aucun cours à afficher.");
                return;
            }

            foreach (var cours in cours)
            {
                Console.WriteLine($"Numéro : {cours.NumeroCours}, Code : {cours.CodeCours}," +
                    $" Titre : {cours.TitreCours}");
            }
        }

        private static void AfficherNotes()
        {
            Console.WriteLine("Liste des notes :");
            if (notes.Count == 0)
            {
                Console.WriteLine("Aucune note à afficher.");
                return;
            }

            foreach (var note in notes)
            {
                Console.WriteLine($"Numéro d'étudiant : {note.NumeroEtudiant}, Numéro du cours : {note.NumeroCours}," +
                    $" Note : {note.NoteCours}");
            }
        }

        private static void SauvegarderDonnees(int numeroEtudiant)
        {
            try
            {
                Etudiant etudiant = etudiants.Find(e => e.NumeroEtudiant == numeroEtudiant);
                if (etudiant != null)
                {
                    string fichierTexte = $"etudiant_{etudiant.NumeroEtudiant}.txt";
                    using (StreamWriter sw = new StreamWriter(fichierTexte))
                    {
                        sw.WriteLine($"Nom : {etudiant.NomEtudiant}");
                        sw.WriteLine($"Prénom : {etudiant.PrenomEtudiant}");
                        sw.WriteLine("Notes :");

                        foreach (var note in notes)
                        {
                            if (note.NumeroEtudiant == etudiant.NumeroEtudiant)
                            {
                                Cours matiere = cours.Find(c => c.NumeroCours == note.NumeroCours);
                                if (matiere != null)
                                {
                                    sw.WriteLine($"{matiere.TitreCours} ({matiere.CodeCours}): {note.NoteCours}");
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Données sauvegardées pour l'étudiant numéro {numeroEtudiant}.");
                }
                else
                {
                    Console.WriteLine("Étudiant non trouvé.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erreur d'écriture : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }

        private static void AfficherReleveDeNotes()
        {
            try
            {
                Console.WriteLine("Veuillez entrer le numéro de l'étudiant:");
                int numeroEtudiant = int.Parse(Console.ReadLine());
                string fichier = $"etudiant_{numeroEtudiant}.txt";
                if (File.Exists(fichier))
                {
                    string[] lines = File.ReadAllLines(fichier);
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Aucun relevé de notes trouvé pour cet étudiant.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erreur de lecture : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }
    }
}

