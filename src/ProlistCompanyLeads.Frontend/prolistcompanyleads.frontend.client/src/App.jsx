import * as React from 'react';
import './App.css';
import { Typography, Box, Tab, Tabs } from '../node_modules/@mui/material/index';
import PropTypes from 'prop-types';
import Invited from './Invited';
import Accepted from './Accepted';

function CustomTabPanel(props) {
    const { children, value, index, ...other } = props;

    return (
        <div
            role="tabpanel"
            hidden={value !== index}
            id={`simple-tabpanel-${index}`}
            aria-labelledby={`simple-tab-${index}`}
            {...other}
        >
            {value === index && (
                <Box sx={{ p: 3 }}>
                    <Typography>{children}</Typography>
                </Box>
            )}
        </div>
    );
}

CustomTabPanel.propTypes = {
    children: PropTypes.node,
    index: PropTypes.number.isRequired,
    value: PropTypes.number.isRequired,
};

function a11yProps(index) {
    return {
        id: `simple-tab-${index}`,
        'aria-controls': `simple-tabpanel-${index}`,
    };
}

export default function App() {
    const [value, setValue] = React.useState(0);

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    return (
        <div>
            <h1 id="tabelLabel">Prolist Company - Leads</h1>
            <p>Lista de leads para avaliação</p>
            <Box sx={{ width: '100%' }}>
                <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
                    <Tabs value={value} onChange={handleChange} aria-label="basic tabs example">
                        <Tab label="Invited" {...a11yProps(0)} />
                        <Tab label="Accepted" {...a11yProps(1)} />
                    </Tabs>
                </Box>
                <CustomTabPanel value={value} index={0}>
                    <Invited></Invited>
                </CustomTabPanel>
                <CustomTabPanel value={value} index={1}>
                    <Accepted></Accepted>
                </CustomTabPanel>
            </Box>
        </div>
    );
}
