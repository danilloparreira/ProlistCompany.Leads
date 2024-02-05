import { useEffect, useState } from 'react';
import { Card, CardContent, Typography, Avatar, CircularProgress } from '../node_modules/@mui/material/index';

export default function Accepted() {
    const [leads, setLeads] = useState();

    useEffect(() => {
        populateLeads();
    }, []);

    async function populateLeads() {
        const response = await fetch('leads/status/1');
        const data = await response.json();
        setLeads(data.leads);
    }

    const conteudo = leads === undefined
        ? <p><CircularProgress></CircularProgress></p>
        : leads.map(lead =>
            <div key={lead.id}>
                <Card key={lead.id} sx={{ minWidth: 275 }}>
                    <CardContent>
                        <Typography variant="h5" component="div">
                            <Avatar>{lead.nome[0]}</Avatar>
                            {lead.nome}
                        </Typography>
                        <Typography variant="h5" component="div">
                            {lead.dataDeInclusao}
                        </Typography>
                        <hr></hr>
                        <Typography sx={{ mb: 1.5 }} color="text.secondary">
                            {lead.suburbio}
                        </Typography>
                        <Typography variant="body2">
                            {lead.categoria}
                        </Typography>
                        <Typography variant="body2">
                            Job ID: {lead.identificador}
                        </Typography>
                        <Typography variant="body2">
                            ${lead.preco} Lead invitation
                        </Typography>
                        <hr></hr>
                        <Typography variant="body2">
                            {lead.telefone}
                        </Typography>
                        <Typography variant="body2">
                            {lead.email}
                        </Typography>
                        <Typography variant="body2">
                            {lead.descricao}
                        </Typography>
                    </CardContent>
                </Card>
                <br></br>
            </div>
        )

    return conteudo;
}
