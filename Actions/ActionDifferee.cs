namespace CollectionDeFilms.Actions
{
    interface ActionDifferee
    {
        void execute();
        string nom();
        void dansLaQueue(bool queued = true);
    }
}
