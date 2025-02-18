using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TolkienApi.Models;

namespace TolkienApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Artefact> Artefacts { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Race> Races { get; set; }

        private readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public DataContext()
        {
            InitQuotes();
            InitCharacters();
            InitArtefacts();
            InitBattles();
            InitCultures();
            InitLocations();
            InitRaces();
        }

        private void InitQuotes()
        {
            if (Quotes.Any()) return;

            string fileContent = File.ReadAllText("Data/quotes.json");
            List<Quote> quotes = JsonSerializer.Deserialize<List<Quote>>(fileContent, JsonOptions);

            Quotes.AddRange(quotes);
            SaveChanges();
        }

        private void InitCharacters()
        {
            if (Characters.Any()) return;

            string fileContent = File.ReadAllText("Data/characters.json");
            List<Character> characters = JsonSerializer.Deserialize<List<Character>>(fileContent, JsonOptions);

            Characters.AddRange(characters);
            SaveChanges();
        }

        private void InitArtefacts()
        {
            if (Artefacts.Any()) return;

            string fileContent = File.ReadAllText("Data/artefacts.json");
            List<Artefact> artefact = JsonSerializer.Deserialize<List<Artefact>>(fileContent, JsonOptions);

            Artefacts.AddRange(artefact);
            SaveChanges();
        }

        private void InitBattles()
        {
            if (Battles.Any()) return;

            string fileContent = File.ReadAllText("Data/battles.json");
            List<Battle> battles = JsonSerializer.Deserialize<List<Battle>>(fileContent, JsonOptions);

            Battles.AddRange(battles);
            SaveChanges();
        }

        public void InitCultures()
        {
            if (Cultures.Any()) return;

            string fileContent = File.ReadAllText("Data/cultures.json");
            List<Culture> cultures = JsonSerializer.Deserialize<List<Culture>>(fileContent, JsonOptions);

            Cultures.AddRange(cultures);
            SaveChanges();
        }

        public void InitLocations()
        {
            if (Locations.Any()) return;

            string fileContent = File.ReadAllText("Data/locations.json");
            List<Location> locations = JsonSerializer.Deserialize<List<Location>>(fileContent, JsonOptions);

            Locations.AddRange(locations);
            SaveChanges();
        }

        public void InitRaces()
        {
            if (Races.Any()) return;

            string fileContent = File.ReadAllText("Data/races.json");
            List<Race> races = JsonSerializer.Deserialize<List<Race>>(fileContent, JsonOptions);

            Races.AddRange(races);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
        }

    }
}