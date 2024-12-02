import {
    useFonts,
    SignikaNegative_300Light,
    SignikaNegative_400Regular,
    SignikaNegative_500Medium,
    SignikaNegative_600SemiBold,
    SignikaNegative_700Bold
} from '@expo-google-fonts/signika-negative';

export default function BaseFont() {
    const [fontsLoaded] = useFonts({
        SignikaNegative_300Light,
        SignikaNegative_400Regular,
        SignikaNegative_500Medium,
        SignikaNegative_600SemiBold,
        SignikaNegative_700Bold
    });

    return (<></>);
}