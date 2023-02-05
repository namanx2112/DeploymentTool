export interface HomeTab {
    tab_name: string,
    tab_header: string,
    tab_unique_name: string,
    tab_type: TabType,
    fields: Fields[]
}

export enum TabType{
    Users, Brands, Franchise, Store, TechComponent, Vendor, TechComponentTools, Analytics
}


export interface Fields{
    field_name: string,
    fieldUniqeName: string,
    field_type: FieldType,
    field_placeholder: string | null,
    invalid: boolean | false,
    regex_validation: string,
    mandatory: boolean,
    conditional_mandatory?: ConditionalOption,
    options?: OptionType[]
}

export enum FieldType{
    text, email, date, time, dropdown, 
}

export interface OptionType{
    optionDisplayName: string,
    optionIndex: number,
    optionOrder: number
}

export interface ConditionalOption{
    field_name: string,
    value: string
}
