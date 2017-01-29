namespace Collection_de_films.Actions
{
    interface ActionDifferee
    {
        void execute();
        string nom();
        void dansLaQueue(bool queued = true );
    }
}
