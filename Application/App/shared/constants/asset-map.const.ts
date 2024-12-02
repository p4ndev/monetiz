export const useAsset = (source : string | undefined | null) => {
    if(source && source.indexOf('http') === -1)
        return `${process.env.EXPO_PUBLIC_BASE_ADDRESS}/${source}`;
    return source;
};