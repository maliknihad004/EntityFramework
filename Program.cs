
CoachService coachService = new CoachService();
PlayerService playerService = new PlayerService();
TrainingSessionService sessionService = new TrainingSessionService();
ParticipationService participationService = new ParticipationService();

while (true)
{
    Console.WriteLine("\n=== Football Training Management ===");

    Console.WriteLine("\nCoaches");
    Console.WriteLine("1. Add Coach");
    Console.WriteLine("2. Display Coaches");
    Console.WriteLine("3. Find Coach");
    Console.WriteLine("4. Update Coach");
    Console.WriteLine("5. Delete Coach");

    Console.WriteLine("\nPlayers");
    Console.WriteLine("6. Add Player");
    Console.WriteLine("7. Display Players");
    Console.WriteLine("8. Find Player");
    Console.WriteLine("9. Update Player");
    Console.WriteLine("10. Delete Player");

    Console.WriteLine("\nTraining Sessions");
    Console.WriteLine("11. Add Session");
    Console.WriteLine("12. Display Sessions");
    Console.WriteLine("13. Find Session");
    Console.WriteLine("14. Update Session");
    Console.WriteLine("15. Delete Session");

    Console.WriteLine("\nParticipation");
    Console.WriteLine("16. Assign Player");
    Console.WriteLine("17. Remove Player");
    Console.WriteLine("18. Display Players in Session");
    Console.WriteLine("19. Display Sessions for Player");

    Console.WriteLine("\n0. Exit");

    Console.Write("\nChoose an option: ");
    string? choice = Console.ReadLine();

    int coachId;
    int playerId;
    int sessionId;

    switch (choice)
    {
        case "1":
            await coachService.AddCoach();
            break;

        case "2":
            await coachService.DisplayCoaches();
            break;

        case "3":
            coachId = ReadId("Enter Coach ID: ");
            if (coachId > 0)
                await coachService.FindCoach(coachId);
            break;

        case "4":
            coachId = ReadId("Enter Coach ID: ");
            if (coachId > 0)
                await coachService.UpdateCoach(coachId);
            break;

        case "5":
            coachId = ReadId("Enter Coach ID: ");
            if (coachId > 0)
                await coachService.DeleteCoach(coachId);
            break;

        case "6":
            await playerService.AddPlayer();
            break;

        case "7":
            await playerService.DisplayPlayers();
            break;

        case "8":
            playerId = ReadId("Enter Player ID: ");
            if (playerId > 0)
                await playerService.FindPlayer(playerId);
            break;

        case "9":
            playerId = ReadId("Enter Player ID: ");
            if (playerId > 0)
                await playerService.UpdatePlayer(playerId);
            break;

        case "10":
            playerId = ReadId("Enter Player ID: ");
            if (playerId > 0)
                await playerService.DeletePlayer(playerId);
            break;

        case "11":
            await sessionService.AddSession();
            break;

        case "12":
            await sessionService.DisplaySessions();
            break;

        case "13":
            sessionId = ReadId("Enter Session ID: ");
            if (sessionId > 0)
                await sessionService.FindSession(sessionId);
            break;

        case "14":
            sessionId = ReadId("Enter Session ID: ");
            if (sessionId > 0)
                await sessionService.UpdateSession(sessionId);
            break;

        case "15":
            sessionId = ReadId("Enter Session ID: ");
            if (sessionId > 0)
                await sessionService.DeleteSession(sessionId);
            break;

        case "16":
            playerId = ReadId("Enter Player ID: ");
            sessionId = ReadId("Enter Session ID: ");

            if (playerId > 0 && sessionId > 0)
                await participationService.AssignPlayer(playerId, sessionId);
            break;

        case "17":
            playerId = ReadId("Enter Player ID: ");
            sessionId = ReadId("Enter Session ID: ");

            if (playerId > 0 && sessionId > 0)
                await participationService.RemovePlayer(playerId, sessionId);
            break;

        case "18":
            sessionId = ReadId("Enter Session ID: ");

            if (sessionId > 0)
                await participationService.DisplayPlayers(sessionId);
            break;

        case "19":
            playerId = ReadId("Enter Player ID: ");

            if (playerId > 0)
                await participationService.DisplaySessions(playerId);
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

static int ReadId(string message)
{
    Console.Write(message);

    if (int.TryParse(Console.ReadLine(), out int id) && id > 0)
        return id;

    Console.WriteLine("Invalid ID");
    return 0;
}