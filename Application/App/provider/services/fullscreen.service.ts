export class FullscreenService
{
    private Error(err){
        console.error("Failed to enable fullscreen mode:", err);
    }

    Enter() {
        if(process.env.EXPO_PUBLIC_ENVIRONMENT === 'Development')
            return;

        if (document && document.documentElement.requestFullscreen)
            document.documentElement.requestFullscreen().catch(this.Error);
    }

    Exit() {
        if(process.env.EXPO_PUBLIC_ENVIRONMENT === 'Development')
            return;
        
        if (document && document.exitFullscreen)
            document.exitFullscreen().catch(this.Error);
    }
}