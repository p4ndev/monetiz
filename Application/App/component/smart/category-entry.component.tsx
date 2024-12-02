import { Image, Pressable } from 'react-native';

import { useAccountContext, useLobbyContext } from '../../provider/contexts';
import { CategoryEntryStyle } from "../../provider/styles";
import { AnalyticService } from '../../provider/services';
import { useDateExpired } from '../../provider/locales';
import { useParser } from '../../provider/handlers';

import { AccountStateInterface, CategoryEntryInterface, CategoryInterface } from "../../shared/interfaces";
import { AppMap, useAsset } from '../../shared/constants';

export default function CategoryEntry(props : CategoryEntryInterface){

    const { lobby, setLobby } = useLobbyContext();
    const { account } = useAccountContext();

    const { nameid, role } = useParser<AccountStateInterface>(account);
    const { id, tenantId, logotype, name, summary, end } = props.source as CategoryInterface;
    
    const analyticService = new AnalyticService();

    const onCategoryClicked = () => {
        setLobby({
            ...lobby,
            categoryName    : name,
            categorySummary : summary,
            categoryId      : Number(id)
        });

        analyticService.TrackEvent('Category Viewed By', { UID: nameid, RID: role, TID: tenantId, CID: id });

        AppMap.Room.Game();
    };

    if (useDateExpired(end) === false)
        return (
            <Pressable style={CategoryEntryStyle.cell} onPress={onCategoryClicked} id={'btnCategory' + id}>
                <Image style={CategoryEntryStyle.icon} source={{ uri: useAsset(logotype) }} resizeMode={'cover'}  />
            </Pressable>
        );
}